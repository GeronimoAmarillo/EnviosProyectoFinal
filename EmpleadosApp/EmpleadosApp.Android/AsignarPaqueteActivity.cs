using System;
using System.Collections.Generic;
using System.Linq;
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
    [Activity(Label = "AsignarPaqueteActivity")]
    public class AsignarPaqueteActivity : Activity
    {
        private EditText etNumReferencia;
        private EditText etClienteReceptor;
        private EditText etLocalEmisor;
        private Entrega entrega;
        private Button btnAsignar;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            VerificarSesion();

            SetContentView(Resource.Layout.AsignarPaqueteActivity);

            try
            {

                Bundle extras = Intent.Extras;
                string entregaJson = extras.GetString("EntregaCreacion");

                entrega = JsonConvert.DeserializeObject<Entrega>(entregaJson);

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
            btnAsignar.Click += btnAsignar_Click;
        }


        private void btnAsignar_Click(object sender, EventArgs e)
        {
            Paquete paqueteAgregar = new Paquete();

            try
            {
                if (!ValidarReferencia(etNumReferencia.Text))
                {
                    etNumReferencia.Error = "Dato invalido: Debe ser un numero";
                    return;
                }

                int numReferencia = Convert.ToInt32(etNumReferencia.Text.ToString());

                if (entrega.ClienteEmisor != null)
                {
                    paqueteAgregar.Cliente = entrega.ClienteEmisor;
                }
                else
                {
                    paqueteAgregar.Cliente = entrega.ClienteReceptor;
                }
                
                paqueteAgregar.Entrega = entrega.Codigo;
                paqueteAgregar.Estado = "Levantado";
                paqueteAgregar.FechaSalida = DateTime.Today;
                paqueteAgregar.NumReferencia = numReferencia;
                paqueteAgregar.Ubicacion = "Local: " + entrega.Locales.Nombre + ", en: " + entrega.Locales.Direccion;


                if (entrega.Paquetes == null)
                {
                    entrega.Paquetes = new List<Paquete>();
                    entrega.Paquetes.Add(paqueteAgregar);
                }
                else
                {
                    entrega.Paquetes.Add(paqueteAgregar);
                }

                try
                {
                    var intent = new Intent(this, typeof(NuevoPaqueteActivity));
                    
                    intent.PutExtra("EntregaCreacion", Newtonsoft.Json.JsonConvert.SerializeObject(entrega));

                    StartActivity(intent);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al intentar redirigir al proximo paso.");
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private bool ValidarReferencia(string text)
        {
            try
            {
                int num = Convert.ToInt32(text);
                return true;
            }
            catch(Exception ex)
            {
                return false;
                throw new Exception("No se pudo validar el numero de referencia.");
            }
        }

        private void SetupViews()
        {
            btnAsignar = FindViewById<Button>(Resource.Id.btnAsignarPaquete);
            etClienteReceptor = FindViewById<EditText>(Resource.Id.etClienteReceptor);
            etLocalEmisor = FindViewById<EditText>(Resource.Id.etLocalEmisor);
            etNumReferencia = FindViewById<EditText>(Resource.Id.etNumReferencia);

            if (entrega.ClienteEmisor != null)
            {
                etClienteReceptor.Text = entrega.ClienteEmisor.ToString();
            }
            else
            {
                etClienteReceptor.Text = entrega.ClienteReceptor.ToString();
            }
            
            etLocalEmisor.Text = entrega.Locales.Nombre;
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