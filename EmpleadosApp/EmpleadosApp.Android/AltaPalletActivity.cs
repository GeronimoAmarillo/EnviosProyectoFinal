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
    [Activity(Label = "Alta Pallet")]
    public class AltaPalletActivity : Activity
    {
        private List<Cliente> clientes;
        private ListView lvClientes;
        private Cliente clienteSeleccionado;
        private int idRack;
        private Button btnAltaCliente;
        private EditText etProducto;
        private EditText etCantidad;
        private EditText etPeso;
        private Button btnAltaPallet;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AltaPalletActivity);

            Bundle extras = Intent.Extras;
            idRack = Convert.ToInt32(extras.Get("RackSeleccionado"));

            try
            {
                if (!clientes.Any())
                {
                    try
                    {
                        ListarClientes();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Se produjo un error al intentar listar los racks.");
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

        private void ListarClientes()
        {
            throw new NotImplementedException();
        }

        private void SetupEvents()
        {
            btnAltaCliente.Click += btnAltaCliente_Click;
            btnAltaPallet.Click += btnAltaPallet_Click;
            lvClientes.ItemSelected += lvClientesItemSelected_ItemClick;
        }

        private void lvClientesItemSelected_ItemClick(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAltaPallet_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lvRacks_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(AltaPalletActivity));
            var id = (int)e.Id;
            intent.PutExtra("RackSeleccionado", id);
            StartActivity(intent);
        }

        private void SetupViews()
        {
            lvClientes = FindViewById<ListView>(Resource.Id.lvClientes);
            btnAltaCliente = FindViewById<Button>(Resource.Id.btnAgregarCliente);
            btnAltaPallet = FindViewById<Button>(Resource.Id.btnAltaPallet);
            etCantidad = FindViewById<EditText>(Resource.Id.etCantidad);
            etPeso = FindViewById<EditText>(Resource.Id.etPeso);
            etProducto = FindViewById<EditText>(Resource.Id.etProducto);
        }

        /*public async System.Threading.Tasks.Task<List<Rack>> ObtenerRacks()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Palets/Galpon?id=1");

                Galpon galpon = null;

                galpon = JsonConvert.DeserializeObject<Galpon>(json);

                var sector = galpon.Sectores.Where(s => s.Codigo == idSector).Select(c => new {
                    Sector = c
                }).FirstOrDefault();

                racks = sector.Sector.Racks;

                return racks;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los racks.");
            }
        }*/
    }
}