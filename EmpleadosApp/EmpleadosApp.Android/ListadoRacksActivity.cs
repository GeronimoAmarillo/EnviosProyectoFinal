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
    [Activity(Label = "ListadoRacksActivity")]
    public class ListadoRacksActivity : Activity
    {
        private List<Rack> racks;
        private ListView lvRacks;
        private int idSector;

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

            SetContentView(Resource.Layout.ListadoRacksActivity);

            Bundle extras = Intent.Extras;
            idSector = Convert.ToInt32(extras.Get("SectorSeleccionado"));

            racks = new List<Rack>();
            
            try
            {
                if (!racks.Any())
                {
                    try
                    {
                        racks = AsyncHelper.RunSync<List<Rack>>(() => ObtenerRacks());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Se produjo un error al intentar listar los racks.");
                    }
                }

                SetupViews();
                SetupEvents();

                lvRacks.Adapter = new Adaptadores.AdaptadorRacks(this, racks);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private void SetupEvents()
        {
            lvRacks.ItemClick += lvRacks_ItemClick;
        }

        private void lvRacks_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(ListadoClientesActivity));
            var id = (int)e.Id;
            intent.PutExtra("RackSeleccionado", id);
            StartActivity(intent);
        }

        private void SetupViews()
        {
            lvRacks = FindViewById<ListView>(Resource.Id.lvRacks);
        }

        public async System.Threading.Tasks.Task<List<Rack>> ObtenerRacks()
        {
            try
            {
                //http://localhost:8080/

                //http://169.254.80.80:8080

                using (var httpClient = new HttpClient(new NativeMessageHandler()))
                {
                    var json = await httpClient.GetStringAsync(ConexionREST.ConexionPalets + "/Galpon?id=1");

                    Galpon galpon = null;

                    galpon = JsonConvert.DeserializeObject<Galpon>(json);

                    var sector = galpon.Sectores.Where(s => s.Codigo == idSector).Select(c => new {
                        Sector = c
                    }).FirstOrDefault();

                    racks = sector.Sector.Racks;

                    return racks;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los racks.");
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