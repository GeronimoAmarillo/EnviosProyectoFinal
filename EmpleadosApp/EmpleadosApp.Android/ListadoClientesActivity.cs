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
    [Activity(Label = "ListadoClientesActivity")]
    public class ListadoClientesActivity : Activity
    {
        private List<Cliente> clientes;
        private ListView lvClientes;
        private Button btnAltaCliente;
        private int idRack;
        private long rutCliente;

        protected override void OnStart()
        {
            base.OnStart();
            var intent = new Intent(this, typeof(ServicioGeolocalizacion));
            StartService(intent);
        }

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

            SetContentView(Resource.Layout.ListadoClienteActivity);

            Bundle extras = Intent.Extras;
            idRack = Convert.ToInt32(extras.Get("RackSeleccionado"));

            clientes = new List<Cliente>();

            try
            {
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

                using (var httpClient = new HttpClient(new NativeMessageHandler()))
                {
                    var json = await httpClient.GetStringAsync(ConexionREST.ConexionPalets + "/Clientes");

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
            var intent = new Intent(this, typeof(AltaPalletActivity));
            var id = (int)e.Id;
            intent.PutExtra("RackSeleccionado", idRack);
            intent.PutExtra("ClienteSeleccionado", id);
            StartActivity(intent);
        }

        private void SetupViews()
        {
            lvClientes = FindViewById<ListView>(Resource.Id.lvClientes);
            btnAltaCliente = FindViewById<Button>(Resource.Id.btnAgregarCliente);
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            //corresponde a otro caso de uso
            throw new NotImplementedException();
        }
    }
}