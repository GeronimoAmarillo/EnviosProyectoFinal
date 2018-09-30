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
    [Activity(Label = "NuevoPaqueteActivity")]
    public class NuevoPaqueteActivity : Activity
    {
        private Entrega entrega;
        private TextView tvLocalEmisor;
        private TextView tvClienteReceptor;
        private TextView tvTurno;
        private ListView lvPaquetes;
        private Button btnNuevoPaquete;
        private Button btnCerrarEntrega;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            VerificarSesion();

            SetContentView(Resource.Layout.NuevoPaqueteActivity);

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
            btnNuevoPaquete.Click += btnNuevoPaquete_Click;
            btnCerrarEntrega.Click += btnCerrarEntrega_Click;
        }

        private void btnCerrarEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                var intent = new Intent(this, typeof(IngresoReceptorActivity));

                intent.PutExtra("EntregaCreacion", Newtonsoft.Json.JsonConvert.SerializeObject(entrega));

                StartActivity(intent);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private void btnNuevoPaquete_Click(object sender, EventArgs e)
        {

            try
            {
                var intent = new Intent(this, typeof(ListadoLocalesActivity));

                intent.PutExtra("EntregaCreacion", Newtonsoft.Json.JsonConvert.SerializeObject(entrega));

                StartActivity(intent);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }
        
        private void SetupViews()
        {
            tvClienteReceptor = FindViewById<TextView>(Resource.Id.tvClienteReceptor);
            tvLocalEmisor = FindViewById<TextView>(Resource.Id.tvLocalEmisor);
            tvTurno = FindViewById<TextView>(Resource.Id.tvTurno);
            btnCerrarEntrega = FindViewById<Button>(Resource.Id.btnTerminar);
            btnNuevoPaquete = FindViewById<Button>(Resource.Id.btnNuevoPaquete);
            lvPaquetes = FindViewById<ListView>(Resource.Id.lvPaquetes);

            tvClienteReceptor.Text = entrega.ClienteReceptor.ToString();
            tvLocalEmisor.Text = entrega.LocalEmisor.ToString();
            tvTurno.Text = entrega.Turno;

            lvPaquetes.Adapter = new Adaptadores.AdaptadorPaquetes(this, entrega.Paquetes);
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