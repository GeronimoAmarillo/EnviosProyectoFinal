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
    public class ListaRacksFragment : Fragment
    {
        private List<Rack> racks;
        private ListView lvRacks;
        private int idSector;

        public ListaRacksFragment(int pIdSector)
        {
            racks = new List<Rack>();
            idSector = pIdSector;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            if (!racks.Any())
            {
                try
                {
                    ObtenerRacks();
                }
                catch (Exception ex)
                {
                    throw new Exception("Se produjo un error al intentar listar los racks.");
                }
            }

            SetupViews();

            SetupEvents();

            lvRacks.Adapter = new Adaptadores.AdaptadorRacks(Activity, racks);
        }

        private void SetupEvents()
        {
            lvRacks.ItemClick += lvRacks_ItemClick;
        }

        private void lvRacks_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(Activity, typeof(SeleccionarUbicacionActivity));
            var id = (int)e.Id;
            intent.PutExtra("RackSeleccionado", id);
            StartActivity(intent);
        }

        private void SetupViews()
        {
            lvRacks = View.FindViewById<ListView>(Resource.Id.lvRacks);
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return inflater.Inflate(Resource.Layout.ListadoRacksFragment, container, false);
        }

        public async System.Threading.Tasks.Task<List<Rack>> ObtenerRacks()
        {
            try
            {
                //http://localhost:8080/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync("http://localhost:8080/api/Palets/Galpon?id=1");

                Galpon galpon = null;

                galpon = JsonConvert.DeserializeObject<Galpon>(json);

                var sector = galpon.Sectores.Where(s => s.Codigo == idSector).Select(c => new {
                    Sector = c
                }).FirstOrDefault();

                racks = sector.Sector.Racks;

                return racks;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los racks.");
            }
        }
    }
}