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
    [Activity(Label = "NuevoPaqueteActivity")]
    public class NuevoPaqueteActivity : Activity
    {
        private Entrega entrega;
        private TextView tvLocalEmisor;
        private TextView tvClienteReceptor;
        private TextView tvCadeteTransportador;
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
                entrega.Locales = null;

                entrega.Fecha = DateTime.UtcNow;

                entrega.NombreReceptor = "";
                try
                {

                    using (var httpClient = new HttpClient())
                    {
                        string url;

                        if (entrega.Turno == null)
                        {
                            url = ConexionREST.ConexionEntregas + "/Levantar";
                        }
                        else
                        {
                            url = ConexionREST.ConexionEntregas + "/Asignar";
                        }
                        

                        string json = JsonConvert.SerializeObject(entrega);

                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        var result = httpClient.PostAsync(url, content).Result;

                        var contentResult = result.Content.ReadAsStringAsync();

                        if (contentResult.Result.ToUpper() == "TRUE")
                        {
                            Toast.MakeText(this, "Se dio de alta con exito la Entrega.", ToastLength.Long).Show();

                            Intent intent = new Intent(this, typeof(InicioActivity));

                            StartActivity(intent);
                        }
                        else
                        {
                            Toast.MakeText(this, "Error al dar de alta la entrega.", ToastLength.Long).Show();
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

        private void btnNuevoPaquete_Click(object sender, EventArgs e)
        {

            try
            {
                var intent = new Intent();

                if (entrega.ClienteEmisor != null)
                {
                    intent = new Intent(this, typeof(ListadoLocalesAsignarActivity));
                }
                else
                {
                    intent = new Intent(this, typeof(ListadoLocalesActivity));
                }
                

                intent.PutExtra("EntregaCreacion", Newtonsoft.Json.JsonConvert.SerializeObject(entrega));
                intent.PutExtra("Nueva", false);

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
            btnCerrarEntrega = FindViewById<Button>(Resource.Id.btnTerminar);
            btnNuevoPaquete = FindViewById<Button>(Resource.Id.btnNuevoPaquete);
            lvPaquetes = FindViewById<ListView>(Resource.Id.lvPaquetes);
            tvTurno = FindViewById<TextView>(Resource.Id.tvTurno);
            tvCadeteTransportador = FindViewById<TextView>(Resource.Id.tvCadeteTransporta);

            if (entrega.ClienteEmisor != null)
            {
                tvClienteReceptor.Text = entrega.ClienteEmisor.ToString();
            }
            else
            {
                tvClienteReceptor.Text = entrega.ClienteReceptor.ToString();
            }

            if (entrega.LocalEmisor != null)
            {
                tvLocalEmisor.Text = entrega.LocalEmisor.ToString();
            }
            else
            {
                tvLocalEmisor.Text = entrega.LocalReceptor.ToString();
            }

            tvCadeteTransportador.Text = entrega.Cadete.ToString();

            tvTurno.Text = entrega.Turno == null? "Turno Generado Automaticamente":entrega.Turno.ToString();
            

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