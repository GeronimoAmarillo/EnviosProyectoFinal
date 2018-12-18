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
using ModernHttpClient;
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
                if (!ValidarProducto(etProducto.Text))
                {
                    etProducto.Error = "Dato invalido: debe tener al menos 2 caracteres y un maximo de 100.";
                    return;
                }

                if (!ValidarPeso(etPeso.Text))
                {
                    etPeso.Error = "Dato invalido: debe ingresar un numero entre 1 - 1500.";
                    return;
                }

                if (!ValidarCantidad(etCantidad.Text))
                {
                    etCantidad.Error = "Dato invalido: debe ingresar un nuermo entre 1 - 20000.";
                    return;
                }

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

                    using (var httpClient = new HttpClient(new NativeMessageHandler()))
                    {

                        string url = ConexionREST.ConexionPalets +"/Palet";

                        var content = new StringContent(JsonConvert.SerializeObject(paletAgregar), Encoding.UTF8, "application/json");

                        var result = httpClient.PostAsync(url, content).Result;

                        var contentResult = result.Content.ReadAsStringAsync();

                        if (contentResult.Result.ToUpper() == "TRUE")
                        {
                            Toast.MakeText(this, "Se dio de alta con exito el pallet.", ToastLength.Long).Show();

                            Intent intent = new Intent(this, typeof(InicioActivity));

                            StartActivity(intent);

                            FinishAffinity();
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

        private bool ValidarCantidad(string text)
        {
            try
            {
                int cantidad = Convert.ToInt32(text);


                if (cantidad < 1 || cantidad > 20000)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();

                return false;
            }
        }

        private bool ValidarPeso(string text)
        {
            try
            {
                decimal peso = Convert.ToDecimal(text);


                if (peso < 1 || peso > 1500)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();

                return false;
            }
        }

        private bool ValidarProducto(string text)
        {
            try
            {
                if (text.Length < 2 || text.Length > 100)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();

                return false;
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