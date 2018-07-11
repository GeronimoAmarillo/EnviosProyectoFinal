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
    [Activity(Label = "ListadoSectoresActivity")]
    public class ListadoSectoresActivity : Activity
    {
        private List<Sector> sectores;
        private ListView lvSectores;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListadoSectoresActivity);

            sectores = new List<Sector>();

            try
            {
                if (!sectores.Any())
                {
                    try
                    {

                        sectores = AsyncHelper.RunSync<List<Sector>>(() => BuscarGalpon());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Se produjo un error al intentar listar los Sectores.");
                    }
                }

                SetupViews();

                SetupEvents();

                lvSectores.Adapter = new Adaptadores.AdaptadorSectores(this, sectores);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private void SetupEvents()
        {
            lvSectores.ItemClick += lvSectores_ItemClick;
        }

        private void lvSectores_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(ListadoRacksActivity));
            var id = (int)e.Id;
            intent.PutExtra("SectorSeleccionado", id);
            StartActivity(intent);
        }

        private void SetupViews()
        {
            lvSectores = FindViewById<ListView>(Resource.Id.lvSectores);
        }

        public async System.Threading.Tasks.Task<List<Sector>> BuscarGalpon()
        {
            try
            {
                //http://169.254.80.80:8080

                using (var httpClient = new HttpClient())
                {
                    var json = await httpClient.GetStringAsync("http://169.254.80.80:8080/api/Palets/Galpon?id=1");

                    Galpon galpon = null;

                    galpon = JsonConvert.DeserializeObject<Galpon>(json);

                    sectores = galpon.Sectores;

                    return sectores;
                }
                

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los sectores.");
            }
        }
    }
}