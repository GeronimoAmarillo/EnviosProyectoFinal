﻿using System;

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

namespace EmpleadosApp.Droid
{
    [Activity(Label = "Login", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            try
            {
                SetContentView(Resource.Layout.MainActivity);

                Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);

                btnLogin.Click += async (sender, e) =>
                {

                    var etUser = FindViewById<EditText>(Resource.Id.etUser);
                    var etPass = FindViewById<EditText>(Resource.Id.etPass);

                    var user = etUser.Text;
                    var pass = etPass.Text;

                    Usuario usuarioLogueado = null;

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
                            Intent intent = new Intent(this, typeof(InicioActivity));
                            intent.PutExtra("UsuarioLogueado", Newtonsoft.Json.JsonConvert.SerializeObject(usuarioLogueado));

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
                //http://localhost:8080/api

                using (var httpClient = new HttpClient())
                {
                    var json = await httpClient.GetStringAsync("http://localhost:50076/api/Usuarios/Login?" + "usuario=" + user + "&contrasenia=" + pass);

                    Usuario usuarioLogueado = null;
                    Administrador admin = null;
                    Cadete cadete = null;
                    Cliente cliente = null;


                    usuarioLogueado = JsonConvert.DeserializeObject<Administrador>(json);

                    admin = (Administrador)usuarioLogueado;

                    if (admin == null || admin.Tipo == null)
                    {
                        usuarioLogueado = JsonConvert.DeserializeObject<Cadete>(json);
                        cadete = (Cadete)usuarioLogueado;

                        if (cadete == null || cadete.TipoLibreta == null)
                        {
                            usuarioLogueado = JsonConvert.DeserializeObject<Cliente>(json);
                            cliente = (Cliente)usuarioLogueado;
                        }
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