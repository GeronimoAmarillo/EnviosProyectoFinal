using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EntidadesCompartidasAndroid;
using ModernHttpClient;
using Newtonsoft.Json;

namespace EmpleadosApp.Droid
{
    [Activity(Label = "ListadoPaletsActivity")]
    public class ListadoPaletsActivity : Activity
    {
        private List<Palet> palets;
        private ListView lvPalets;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListadoPaletsActivity);


            palets = new List<Palet>();

            try
            {
                if (!palets.Any())
                {
                    try
                    {
                        palets = AsyncHelper.RunSync<List<Palet>>(() => ListarPalets());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Se produjo un error al intentar listar los pallets.");
                    }
                }

                SetupViews();
                SetupEvents();

                lvPalets.Adapter = new Adaptadores.AdaptadorPalets(this, palets);

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private async Task<List<Palet>> ListarPalets()
        {
            try
            {
                //http://169.254.80.80:8080

                using (var httpClient = new HttpClient(new NativeMessageHandler()))
                {
                    var json = await httpClient.GetStringAsync(ConexionREST.ConexionPalets + "/Palets");

                    List<Palet> palets = null;

                    palets = JsonConvert.DeserializeObject<List<Palet>>(json);

                    return palets;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los pallets.");
            }
        }

        private void SetupEvents()
        {
            lvPalets.ItemClick += lvPalets_ItemClick;
        }

        private void lvPalets_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(BajaPaletActivity));
            var id = (int)e.Id;
            intent.PutExtra("PalletSeleccionado", id);
            StartActivity(intent);
        }

        private void SetupViews()
        {
            lvPalets = FindViewById<ListView>(Resource.Id.lvPalets);
        }
    }
}