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
        private int rutCliente;
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
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Palets/Clientes");

                List<Cliente> clientes = null;

                clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los clientes.");
            }
        }

        private void SetupEvents()
        {
            btnAltaCliente.Click += btnAltaCliente_Click;
            btnAltaPallet.Click += btnAltaPallet_Click;
            lvClientes.ItemSelected += lvClientesItemSelected_ItemClick;
        }

        private void lvClientesItemSelected_ItemClick(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            try
            {
                rutCliente = Convert.ToInt32(e.Id);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private void btnAltaPallet_Click(object sender, EventArgs e)
        {
            Palet paletAgregar = new Palet();

            try
            {
                string producto = etProducto.Text.ToString();
                decimal peso = Convert.ToDecimal(etPeso.Text);
                int cantidad = Convert.ToInt32(etCantidad.Text);

                paletAgregar.Cantidad = cantidad;
                paletAgregar.Peso = peso;
                paletAgregar.Producto = producto;
                paletAgregar.Casilla = idRack;
                paletAgregar.Cliente = rutCliente;

                try
                {

                    HttpClient client = new HttpClient();

                    string url = "http://localhost:8080/api/Palets/Palet";

                    var content = new StringContent(JsonConvert.SerializeObject(paletAgregar), Encoding.UTF8, "application/json");

                    var result = client.PostAsync(url, content).Result;

                    if (result.Content.ToString().ToUpper() == "TRUE")
                    {
                        Toast.MakeText(this, "Se dio de alta con exito el pallet.", ToastLength.Long).Show();
                    }
                    else
                    {
                        Toast.MakeText(this, "Error al dar de alta el palet.", ToastLength.Long).Show();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR!: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            //corresponde a otro caso de uso
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
        
    }
}