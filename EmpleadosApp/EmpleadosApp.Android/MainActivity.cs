using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using EntidadesCompartidas;
using LogicaDeApps;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json;
using Android.Content;

namespace EmpleadosApp.Droid
{
    [Activity(Label = "EmpleadosApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MainActivity);

            Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);

            btnLogin.Click += async (sender, e) =>
            {

                var etUser = FindViewById<EditText>(Resource.Id.etUser);
                var etPass = FindViewById<EditText>(Resource.Id.etPass);

                var user = etUser.Text;
                var pass = etPass.Text;

                var logica = FabricaApps.GetControladorUsuario();
                Usuario usuarioLogueado = null;

                try
                {
                    usuarioLogueado = await logica.Login(user, pass);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al loguearse, " + ex.Message);
                }


                if (usuarioLogueado != null)
                {
                    if (usuarioLogueado.NombreUsuario == user && usuarioLogueado.Contraseña == pass)
                    {
                        Intent intent = new Intent(this, typeof(InicioActivity));
                        intent.PutExtra("usuarioLogueado", Newtonsoft.Json.JsonConvert.SerializeObject(usuarioLogueado));

                        StartActivity(intent);
                    }
                }
            };
        }

        /*private async Task Login_ClickAsync(object sender, EventArgs e)
        {
            
        }*/

    }

    
}

