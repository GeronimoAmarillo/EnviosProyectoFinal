using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
    [Activity(Label = "ListarEntregasActivity")]
    public class ListarEntregasActivity : Activity
    {

        private List<Entrega> entregas;
        private ListView lvEntregasAsignadas;
        private ListView lvEntregasLevantadas;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            VerificarSesion();

            SetContentView(Resource.Layout.ListarEntregasActivity);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application);
            string json = prefs.GetString("UsuarioLogueado", "N/L");

            Cadete cadeteLogueado = JsonConvert.DeserializeObject<Cadete>(json);


            try
            {
                entregas = new List<Entrega>();

                if (!entregas.Any())
                {
                    try
                    {
                        entregas = AsyncHelper.RunSync<List<Entrega>>(() => ListarEntregas(cadeteLogueado.Ci));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Se produjo un error al intentar listar las entregas.");
                    }
                }

                List<Entrega> entregasAsignadas = new List<Entrega>();
                List<Entrega> entregasLevantadas = new List<Entrega>();

                entregasAsignadas = entregas.Where(x => x.LocalReceptor != null).ToList();
                entregasLevantadas = entregas.Where(x => x.LocalEmisor != null).ToList();

                SetupViews();
                SetupEvents();

                lvEntregasAsignadas.Adapter = new Adaptadores.AdaptadorEntregasAsignadas(this, entregasAsignadas);
                lvEntregasLevantadas.Adapter = new Adaptadores.AdaptadorEntregasLevantadas(this, entregasLevantadas);

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private async Task<List<Entrega>> ListarEntregas(int cadete)
        {
            try
            {

                using (var httpClient = new HttpClient(new NativeMessageHandler()))
                {
                    var json = await httpClient.GetStringAsync(ConexionREST.ConexionEntregas + "/Listar?cadete=" + cadete);

                    List<Entrega> entregas = null;

                    entregas = JsonConvert.DeserializeObject<List<Entrega>>(json);

                    return entregas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar las entregas.");
            }
        }

        private void SetupEvents()
        {
            lvEntregasAsignadas.ItemClick += lvEntregasAsignadas_ItemClick;
            lvEntregasLevantadas.ItemClick += lvEntregasLevantadas_ItemClick;
        }

        private void lvEntregasLevantadas_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            try
            {
                var intent = new Intent(this, typeof(EntregarLevantadaActivity));
                var id = (int)e.Id;

                Entrega entrega = entregas.Where(x => x.Codigo == id).FirstOrDefault();

                string entregaString = JsonConvert.SerializeObject(entrega);

                intent.PutExtra("EntregaSeleccionada", entregaString);
                StartActivity(intent);
            }

            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: Al verificar la sesion de usuario.", ToastLength.Long).Show();
            }
           
        }

        private void lvEntregasAsignadas_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            try
            {
                var intent = new Intent(this, typeof(EntregarAsignadaActivity));
                var id = (int)e.Id;

                Entrega entrega = entregas.Where(x => x.Codigo == id).FirstOrDefault();

                string entregaString = JsonConvert.SerializeObject(entrega);

                intent.PutExtra("EntregaSeleccionada", entregaString);
                StartActivity(intent);
            }

            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: Al verificar la sesion de usuario.", ToastLength.Long).Show();
            }
        }

        private void SetupViews()
        {
            lvEntregasAsignadas = FindViewById<ListView>(Resource.Id.lvEntregasAsignadas);
            lvEntregasLevantadas = FindViewById<ListView>(Resource.Id.lvEntregasLevantadas);
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