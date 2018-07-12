using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
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
        private int idRack;
        private long rutCliente;
        private EditText etProducto;
        private EditText etCantidad;
        private EditText etPeso;
        private Button btnAltaPallet;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            VerificarSesion();

            SetContentView(Resource.Layout.AltaPalletActivity);

            try
            {

                Bundle extras = Intent.Extras;
                idRack = Convert.ToInt32(extras.Get("RackSeleccionado"));
                rutCliente = Convert.ToInt32(extras.Get("ClienteSeleccionado"));

                SetupViews();
                SetupEvents();
                
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        

        private void SetupEvents()
        {
            btnAltaPallet.Click += btnAltaPallet_Click;
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

                    using (var httpClient = new HttpClient())
                    {

                        string url = "http://169.254.80.80:8080/api/Palets/Palet";

                        var content = new StringContent(JsonConvert.SerializeObject(paletAgregar), Encoding.UTF8, "application/json");

                        var result = httpClient.PostAsync(url, content).Result;

                        var contentResult = result.Content.ReadAsStringAsync();

                        if (contentResult.Result.ToUpper() == "TRUE")
                        {
                            Toast.MakeText(this, "Se dio de alta con exito el pallet.", ToastLength.Long).Show();

                            Intent intent = new Intent(this, typeof(InicioActivity));

                            StartActivity(intent);
                        }
                        else
                        {
                            Toast.MakeText(this, "Error al dar de alta el palet.", ToastLength.Long).Show();
                        }
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

        

        private void SetupViews()
        {
            btnAltaPallet = FindViewById<Button>(Resource.Id.btnAltaPallet);
            etCantidad = FindViewById<EditText>(Resource.Id.etCantidad);
            etPeso = FindViewById<EditText>(Resource.Id.etPeso);
            etProducto = FindViewById<EditText>(Resource.Id.etProducto);
        }

        public void VerificarSesion()
        {
            try
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                string user = prefs.GetString("UsuarioLogueado", "");

                if (user == "")
                {
                    Toast.MakeText(this, "Acceso Denegado: No hay ningun usuario logueado", ToastLength.Long).Show();

                    var intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                }
            }

            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: Al verificar la sesion de usuario.", ToastLength.Long).Show();
            }

        }

    }
}