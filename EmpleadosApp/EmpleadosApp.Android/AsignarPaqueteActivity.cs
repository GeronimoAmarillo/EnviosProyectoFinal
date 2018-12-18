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
        private EditText etCadeteTransportador;
        private EditText etTurno;
        private Entrega entrega;
        private Button btnAsignar;

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
            etCadeteTransportador = FindViewById<EditText>(Resource.Id.etCadeteTransportador);
            etTurno = FindViewById<EditText>(Resource.Id.etTurno);

            if (entrega.ClienteEmisor != null)
            {
                etClienteReceptor.Text = "Cliente: " + entrega.ClienteEmisor.ToString();
            }
            else
            {
                etClienteReceptor.Text = "Local: " + entrega.ClienteReceptor.ToString();
            }
            
            etLocalEmisor.Text = entrega.Locales.Nombre;

            if (entrega.Cadete != null)
            {
                etCadeteTransportador.Text = "Transporta: " + entrega.Cadete.ToString();
            }
            else
            {
                etCadeteTransportador.Text = "Transporta: Asignacion Automatica";
            }

            if (entrega.Cadete != null)
            {
                etCadeteTransportador.Text = "Transporta: " + entrega.Cadete.ToString();
            }
            else
            {
                etCadeteTransportador.Text = "Transporta: Asignacion Automatica";
            }

            if (entrega.Turno != null)
            {
                if (entrega.Turno != "")
                {
                    etTurno.Text = "Turno: " + entrega.Turno.ToString();
                }
                else
                {
                    etTurno.Text = "Turno: Asignacion Automatica";
                }
            }
            else
            {
                etTurno.Text = "Turno: Asignacion Automatica";
            }
            
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