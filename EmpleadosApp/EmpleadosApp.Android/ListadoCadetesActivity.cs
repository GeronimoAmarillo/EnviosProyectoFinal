using System;
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
using ModernHttpClient;
using Newtonsoft.Json;

namespace EmpleadosApp.Droid
{
    [Activity(Label = "ListadoCadetesActivity")]
    public class ListadoCadetesActivity : Activity
    {
        private List<Cadete> cadetes;
        private ListView lvCadetes;
        private Entrega entrega;
        
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();

            if (item.TitleFormatted.ToString().ToLower() == "inicio")
            {
                Intent intent = new Intent(this, typeof(InicioActivity));

                StartActivity(intent);
            }
            else
            {
                Intent intent = new Intent(this, typeof(MainActivity));

                StartActivity(intent);

                FinishAffinity();
            }

            return base.OnOptionsItemSelected(item);
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListadoCadetesActivity);


            try
            {

                Bundle extras = Intent.Extras;
                string entregaJson = extras.GetString("EntregaCreacion");

                entrega = JsonConvert.DeserializeObject<Entrega>(entregaJson);

                cadetes = new List<Cadete>();

                if (!cadetes.Any())
                {
                    try
                    {
                        cadetes = AsyncHelper.RunSync<List<Cadete>>(() => ListarCadetes());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Se produjo un error al intentar listar los cadetes.");
                    }
                }

                SetupViews();
                SetupEvents();

                lvCadetes.Adapter = new Adaptadores.AdaptadorCadetes(this, cadetes);

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private async System.Threading.Tasks.Task<List<Cadete>> ListarCadetes()
        {
            try
            {
                //http://169.254.80.80:8080

                using (var httpClient = new HttpClient(new NativeMessageHandler()))
                {
                    var json = await httpClient.GetStringAsync(ConexionREST.ConexionEntregas + "/Cadetes");

                    List<Cadete> cadetes = null;

                    cadetes = JsonConvert.DeserializeObject<List<Cadete>>(json);

                    return cadetes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los cadetes.");
            }
        }

        private void SetupEvents()
        {
            lvCadetes.ItemClick += lvCadetes_ItemClick;
        }

        private void lvCadetes_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(ListadoTurnosActivity));
            var id = (int)e.Id;

            entrega.Cadete = id;

            intent.PutExtra("EntregaCreacion", Newtonsoft.Json.JsonConvert.SerializeObject(entrega));

            StartActivity(intent);
        }

        private void SetupViews()
        {
            lvCadetes = FindViewById<ListView>(Resource.Id.lvCadetes);
        }
    }
}