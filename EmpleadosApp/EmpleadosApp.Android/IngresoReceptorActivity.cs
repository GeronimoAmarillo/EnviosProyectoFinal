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
    [Activity(Label = "IngresoReceptorActivity")]
    public class IngresoReceptorActivity : Activity
    {
        private Entrega entrega;
        private EditText etReceptor;
        private Button btnConfirmarReceptor;
        

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

            SetContentView(Resource.Layout.IngresoDeReceptor);

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
            btnConfirmarReceptor.Click += btnConfirmarReceptor_Click;
        }


        private void btnConfirmarReceptor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarReceptor(etReceptor.Text))
                {
                    etReceptor.Error = "Dato invalido: debe ingresar el nombre del receptor y no debe tener mas de 50 caracteres.";
                    return;
                }

                entrega.NombreReceptor = etReceptor.Text;

                try
                {

                    using (var httpClient = new HttpClient(new NativeMessageHandler()))
                    {

                        string url = ConexionREST.ConexionEntregas + "/Entregar";

                        var content = new StringContent(JsonConvert.SerializeObject(entrega), Encoding.UTF8, "application/json");

                        var result = httpClient.PostAsync(url, content).Result;

                        var contentResult = result.Content.ReadAsStringAsync();

                        if (contentResult.Result.ToUpper() == "TRUE")
                        {
                            Toast.MakeText(this, "Se entrego con exito la Entrega.", ToastLength.Long).Show();

                            Intent intent = new Intent(this, typeof(ListarEntregasActivity));

                            StartActivity(intent);

                            FinishAffinity();
                        }
                        else
                        {
                            Toast.MakeText(this, "Error al entregar la entrega.", ToastLength.Long).Show();
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

        private bool ValidarReceptor(string text)
        {
            try
            {
                if (text == null || text.Length == 0)
                {
                    return false;
                }
                else if (text.Length > 50)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();

                return false;
            }
        }
        

        private void SetupViews()
        {
            btnConfirmarReceptor = FindViewById<Button>(Resource.Id.btnReceptor);
            etReceptor = FindViewById<EditText>(Resource.Id.etReceptor);
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