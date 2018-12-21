using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Android.Content;
using EntidadesCompartidasAndroid;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using System.Net;
using ModernHttpClient;

namespace EmpleadosApp.Droid
{
    [Activity(Label = "EnviosService", Icon = "@drawable/LogoNuevoColor", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {

        //public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        //{
        //    return true;
        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            try
            {

                Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);
                SetContentView(Resource.Layout.MainActivity);

                Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);

                btnLogin.Click += async (sender, e) =>
                {

                    var etUser = FindViewById<EditText>(Resource.Id.etUser);
                    var etPass = FindViewById<EditText>(Resource.Id.etPass);

                    var user = etUser.Text;
                    var pass = etPass.Text;

                    Usuario usuarioLogueado = null;

                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };

                    try
                    {
                        usuarioLogueado = await Login(user, pass);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al loguearse, " + ex.Message);
                    }


                    if (usuarioLogueado != null)
                    {
                        if (usuarioLogueado.NombreUsuario == user && usuarioLogueado.Contraseña == pass)
                        {
                            string json = "";

                            if (usuarioLogueado is Administrador)
                            {
                                json = Newtonsoft.Json.JsonConvert.SerializeObject((Administrador)usuarioLogueado, settings);
                            }
                            else if (usuarioLogueado is Cadete)
                            {
                                json = Newtonsoft.Json.JsonConvert.SerializeObject((Cadete)usuarioLogueado, settings);
                            }
                            else
                            {
                                json = Newtonsoft.Json.JsonConvert.SerializeObject(usuarioLogueado, settings);
                            }
                            
                            

                            Intent intent = new Intent(this, typeof(InicioActivity));

                            intent.PutExtra("UsuarioLogueado", json);

                            StartActivity(intent);
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }

        }

        public async Task<Usuario> Login(string user, string pass)
        {
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

                //ip correcta: 169.254.80.80 
                using (var httpClient = new HttpClient(new NativeMessageHandler()))
                {

                    var json = await httpClient.GetStringAsync(ConexionREST.ConexionUsuarios + "/LoginDroid?" + "usuario=" + user + "&contrasenia=" + pass);

                    Usuario usuarioLogueado = null;
                    Administrador admin = null;
                    Cadete cadete = null;

                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };

                    usuarioLogueado = JsonConvert.DeserializeObject<Usuario>(json,settings);


                    if (usuarioLogueado is Administrador)
                    {
                        usuarioLogueado = JsonConvert.DeserializeObject<Administrador>(json, settings);
                    }
                    else if (usuarioLogueado is Cadete)
                    {
                        usuarioLogueado = JsonConvert.DeserializeObject<Cadete>(json, settings);
                    }
                    else
                    {
                        Toast.MakeText(this, "ERROR: Error de Logueo", ToastLength.Long).Show();

                        return null;
                    }
                    

                    return usuarioLogueado;
                }

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();

                return null;
            }
        }
        
    }
}