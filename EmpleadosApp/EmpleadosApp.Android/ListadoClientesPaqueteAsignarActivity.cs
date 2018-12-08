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
using Newtonsoft.Json;

namespace EmpleadosApp.Droid
{
    [Activity(Label = "ListadoClientesPaqueteAsignarActivity")]
    public class ListadoClientesPaqueteAsignarActivity : Activity
    {
        private List<Cliente> clientes;
        private ListView lvClientes;
        private Entrega entrega;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListadoClienteActivity);


            try
            {

                Bundle extras = Intent.Extras;
                string entregaJson = extras.GetString("EntregaCreacion");

                entrega = JsonConvert.DeserializeObject<Entrega>(entregaJson);

                clientes = new List<Cliente>();

                if (!clientes.Any())
                {
                    try
                    {
                        clientes = AsyncHelper.RunSync<List<Cliente>>(() => ListarClientes());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Se produjo un error al intentar listar los clientes.");
                    }
                }

                SetupViews();
                SetupEvents();

                lvClientes.Adapter = new Adaptadores.AdaptadorClientes(this, clientes);

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private async System.Threading.Tasks.Task<List<Cliente>> ListarClientes()
        {
            try
            {
                //http://169.254.80.80:8080

                using (var httpClient = new HttpClient())
                {
                    var json = await httpClient.GetStringAsync(ConexionREST.ConexionEntregas + "/Clientes");

                    List<Cliente> clientes = null;

                    clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);

                    return clientes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los clientes.");
            }
        }

        private void SetupEvents()
        {
            lvClientes.ItemClick += lvClientes_ItemClick;
        }

        private void lvClientes_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(ListadoCadetesActivity));
            var id = (int)e.Id;

            entrega.ClienteEmisor = id;

            intent.PutExtra("EntregaCreacion", Newtonsoft.Json.JsonConvert.SerializeObject(entrega));

            StartActivity(intent);
        }

        private void SetupViews()
        {
            lvClientes = FindViewById<ListView>(Resource.Id.lvClientes);
        }
    }
}