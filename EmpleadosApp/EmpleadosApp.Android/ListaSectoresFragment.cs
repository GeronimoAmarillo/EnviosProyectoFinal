using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using EntidadesCompartidasAndroid;
using Newtonsoft.Json;

namespace EmpleadosApp.Droid
{
    public class ListaSectoresFragment : Fragment
    {

        private List<Sector> sectores;
        private ListView lvSectores;

        public ListaSectoresFragment()
        {
            sectores = new List<Sector>();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            if (!sectores.Any())
            {
                try
                {
                    BuscarGalpon();
                }
                catch (Exception ex)
                {
                    throw new Exception("Se produjo un error al intentar listar los racks.");
                }
            }

            SetupViews();

            SetupEvents();

            lvSectores.Adapter = new Adaptadores.AdaptadorSectores(Activity, sectores);
        }

        private void SetupEvents()
        {
            lvSectores.ItemClick += lvSectores_ItemClick;
        }

        private void lvSectores_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(Activity, typeof(SeleccionarUbicacionActivity));
            var id = (int)e.Id;
            intent.PutExtra("SectorSeleccionado", id);
            StartActivity(intent);
        }

        private void SetupViews()
        {
            lvSectores = View.FindViewById<ListView>(Resource.Id.lvSectores);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return inflater.Inflate(Resource.Layout.ListadoSectoresFragment, container, false);
        }

        public async System.Threading.Tasks.Task<List<Sector>> BuscarGalpon()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Palets/Galpon?id=1");

                Galpon galpon = null;

                galpon = JsonConvert.DeserializeObject<Galpon>(json);

                sectores = galpon.Sectores;

                return sectores;

            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los sectores.");
            }
        }
    }
}