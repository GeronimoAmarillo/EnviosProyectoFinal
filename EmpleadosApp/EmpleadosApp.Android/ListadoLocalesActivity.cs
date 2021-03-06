﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EntidadesCompartidasAndroid;
using Newtonsoft.Json;

namespace EmpleadosApp.Droid
{
    [Activity(Label = "ListadoLocalesActivity")]
    public class ListadoLocalesActivity : Activity
    {
        private List<Local> locales;
        private ListView lvLocales;
        private Entrega entrega;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListadoLocalesActivity);

            

            try
            {
                Bundle extras = Intent.Extras;
                string entregaJson = extras.GetString("EntregaCreacion");
                entrega = JsonConvert.DeserializeObject<Entrega>(entregaJson);

                bool entregaNueva = extras.GetBoolean("Nueva");

                if (entregaNueva)
                {
                    locales = new List<Local>();

                    if (!locales.Any())
                    {
                        try
                        {
                            locales = AsyncHelper.RunSync<List<Local>>(() => ListarLocales());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Se produjo un error al intentar listar los locales.");
                        }
                    }

                    SetupViews();
                    SetupEvents();

                    lvLocales.Adapter = new Adaptadores.AdaptadorLocales(this, locales);
                }
                else
                {
                    try
                    {
                        var intent = new Intent(this, typeof(AsignarPaqueteActivity));
                        
                        intent.PutExtra("EntregaCreacion", Newtonsoft.Json.JsonConvert.SerializeObject(entrega));

                        StartActivity(intent);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al avanzar.");
                    }
                }

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private async System.Threading.Tasks.Task<List<Local>> ListarLocales()
        {
            try
            {

                using (var httpClient = new HttpClient())
                {
                    var json = await httpClient.GetStringAsync(ConexionREST.ConexionLocales + "/Locales");

                    List<Local> locales = null;

                    locales = JsonConvert.DeserializeObject<List<Local>>(json);

                    return locales;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los locales.");
            }
        }

        private async System.Threading.Tasks.Task<Local> BuscarLocal(int id)
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(ConexionREST.ConexionLocales + "/Local?id=" + id);

                Local local = null;

                local = JsonConvert.DeserializeObject<Local>(json);

                return local;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el local.");
            }
        }

        private void SetupEvents()
        {
            lvLocales.ItemClick += lvLocales_ItemClick;
        }

        private void lvLocales_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            try
            {
                var intent = new Intent(this, typeof(ListadoClientesPaqueteActivity));
                var id = (int)e.Id;

                Local localEmisor = AsyncHelper.RunSync<Local>(() => BuscarLocal(id));
                entrega.LocalEmisor = id;
                entrega.Locales = localEmisor;
                
                intent.PutExtra("EntregaCreacion", Newtonsoft.Json.JsonConvert.SerializeObject(entrega));

                StartActivity(intent);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al seleccionar el local.");
            }
            
        }

        private void SetupViews()
        {
            lvLocales = FindViewById<ListView>(Resource.Id.lvLocalesEmisores);
        }
    }
}