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
    [Activity(Label = "EntregarLevantadaActivity")]
    public class EntregarLevantadaActivity : Activity
    {
        private Entrega entrega;
        private TextView tvLocalEmisor;
        private TextView tvClienteReceptor;
        private ListView lvPaquetes;
        private Button btnIrNombreReceptor;

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

            SetContentView(Resource.Layout.EntregarLevantadaActivity);

            try
            {

                Bundle extras = Intent.Extras;
                string entregaJson = extras.GetString("EntregaSeleccionada");

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
            btnIrNombreReceptor.Click += btnIrNombreReceptor_Click;
        }


        private void btnIrNombreReceptor_Click(object sender, EventArgs e)
        {

            try
            {
                var intent = new Intent(this, typeof(IngresoReceptorActivity));

                intent.PutExtra("EntregaSeleccionada", Newtonsoft.Json.JsonConvert.SerializeObject(entrega));

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
            lvPaquetes = FindViewById<ListView>(Resource.Id.lvPaquetes);
            btnIrNombreReceptor = FindViewById<Button>(Resource.Id.btnIrNombreReceptor);

            tvClienteReceptor.Text = entrega.Clientes1.Nombre + " / " + entrega.Clientes1.Direccion;
            tvLocalEmisor.Text = entrega.Locales.Nombre + " / " + entrega.Locales.Direccion;

            lvPaquetes.Adapter = new Adaptadores.AdaptadorPaquetes(this, entrega.Paquetes1);
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