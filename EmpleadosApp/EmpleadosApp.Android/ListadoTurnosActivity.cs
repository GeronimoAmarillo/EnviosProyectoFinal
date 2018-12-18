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
using ModernHttpClient;
using Newtonsoft.Json;

namespace EmpleadosApp.Droid
{
    [Activity(Label = "ListadoTurnosActivity")]
    public class ListadoTurnosActivity : Activity
    {
        private List<Turno> turnos;
        private ListView lvTurnos;
        private Entrega entrega;
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

            SetContentView(Resource.Layout.ListadoTurnosActivity);


            try
            {

                Bundle extras = Intent.Extras;
                string entregaJson = extras.GetString("EntregaCreacion");

                entrega = JsonConvert.DeserializeObject<Entrega>(entregaJson);

                turnos = new List<Turno>();

                if (!turnos.Any())
                {
                    try
                    {
                        turnos = AsyncHelper.RunSync<List<Turno>>(() => ListarTurnos());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Se produjo un error al intentar listar los turnos.");
                    }
                }

                SetupViews();
                SetupEvents();

                lvTurnos.Adapter = new Adaptadores.AdaptadorTurnos(this, turnos);

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private async System.Threading.Tasks.Task<List<Turno>> ListarTurnos()
        {
            try
            {
                //http://169.254.80.80:8080

                using (var httpClient = new HttpClient(new NativeMessageHandler()))
                {
                    var json = await httpClient.GetStringAsync(ConexionREST.ConexionTurnos + "/Turnos");

                    List<Turno> turnos = null;

                    turnos = JsonConvert.DeserializeObject<List<Turno>>(json);

                    foreach (Turno t in turnos)
                    {
                        if (t.Codigo.Substring(0, 3).ToUpper() == "LUN")
                        {
                            t.Id = Convert.ToInt32("1"+t.Codigo.Substring(3, 4));
                        }
                        if (t.Codigo.Substring(0, 3).ToUpper() == "MAR")
                        {
                            t.Id = Convert.ToInt32("2" + t.Codigo.Substring(3, 4));
                        }
                        if (t.Codigo.Substring(0, 3).ToUpper() == "MIE")
                        {
                            t.Id = Convert.ToInt32("3" + t.Codigo.Substring(3, 4));
                        }
                        if (t.Codigo.Substring(0, 3).ToUpper() == "JUE")
                        {
                            t.Id = Convert.ToInt32("4" + t.Codigo.Substring(3, 4));
                        }
                        if (t.Codigo.Substring(0, 3).ToUpper() == "VIE")
                        {
                            t.Id = Convert.ToInt32("5" + t.Codigo.Substring(3, 4));
                        }
                        if (t.Codigo.Substring(0, 3).ToUpper() == "SAB")
                        {
                            t.Id = Convert.ToInt32("6" + t.Codigo.Substring(3, 4));
                        }
                        if (t.Codigo.Substring(0, 3).ToUpper() == "DOM")
                        {
                            t.Id = Convert.ToInt32("7" + t.Codigo.Substring(3, 4));
                        }
                    }

                    return turnos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar listar los turnos.");
            }
        }

        private void SetupEvents()
        {
            lvTurnos.ItemClick += lvTurnos_ItemClick;
        }

        private void lvTurnos_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(AsignarPaqueteActivity));
            var id = (int)e.Id;

            string codigo = "";

            if (id.ToString()[0].ToString() == "1")
            {
                codigo = "LUN" + id.ToString().Substring(1, 4);
            }
            if (id.ToString()[0].ToString() == "2")
            {
                codigo = "MAR" + id.ToString().Substring(1, 4);
            }
            if (id.ToString()[0].ToString() == "3")
            {
                codigo = "MIE" + id.ToString().Substring(1, 4);
            }
            if (id.ToString()[0].ToString() == "4")
            {
                codigo = "JUE" + id.ToString().Substring(1, 4);
            }
            if (id.ToString()[0].ToString() == "5")
            {
                codigo = "VIE" + id.ToString().Substring(1, 4);
            }
            if (id.ToString()[0].ToString() == "6")
            {
                codigo = "SAB" + id.ToString().Substring(1, 4);
            }
            if (id.ToString()[0].ToString() == "7")
            {
                codigo = "DOM" + id.ToString().Substring(1, 4);
            }

            entrega.Turno = codigo;

            intent.PutExtra("EntregaCreacion", Newtonsoft.Json.JsonConvert.SerializeObject(entrega));

            StartActivity(intent);
        }

        private void SetupViews()
        {
            lvTurnos = FindViewById<ListView>(Resource.Id.lvTurnos);
        }
    }
}