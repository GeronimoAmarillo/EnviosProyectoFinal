﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EntidadesCompartidasAndroid;
using Newtonsoft.Json;

namespace EmpleadosApp.Droid
{
    [Activity(Label = "Inicio")]
    public class InicioActivity : Activity
    {
        Button btnIrAltaPalet;
        Button btnIrBajaPalet;
        Button btnEntregar;
        Button btnIrLevanteEntrega;
        Button btnIrRegistroEntrega;
        Usuario usuarioLogueado;

        protected override void OnStart()
        {
            base.OnStart();
            var intent = new Intent(this, typeof(ServicioGeolocalizacion));
            StartService(intent);
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            try
            {
                SetContentView(Resource.Layout.InicioActivity);
                
                Bundle extras = Intent.Extras;

                string usuarioL = "";

                if (extras != null)
                {
                    
                    usuarioL = extras.GetString("UsuarioLogueado");

                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application);
                    ISharedPreferencesEditor editor = prefs.Edit();
                    editor.PutString("UsuarioLogueado", usuarioL);
                    editor.Apply();

                    usuarioLogueado = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(usuarioL);

                    SetupViews();
                    SetupEvents();

                }
                else
                {

                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application);
                    string json = prefs.GetString("UsuarioLogueado", "N/L");

                    if (json != "N/L")
                    {
                        SetupViews();
                        SetupEvents();

                        usuarioLogueado = JsonConvert.DeserializeObject<Usuario>(json);

                        if (usuarioLogueado == null)
                        {
                            Toast.MakeText(this, "No hay usuario Logueado, logueese para utilizar esta función", ToastLength.Long).Show();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }

        }

        private void ConvertirUsuarioBundle(Object usuario)
        {
            try
            {
                usuarioLogueado = new Usuario();
                usuarioLogueado.Clientes = ((Usuario)usuario).Clientes;
                usuarioLogueado.Contraseña = ((Usuario)usuario).Contraseña;
                usuarioLogueado.Direccion = ((Usuario)usuario).Direccion;
                usuarioLogueado.Email = ((Usuario)usuario).Email;
                usuarioLogueado.Empleados = ((Usuario)usuario).Empleados;
                usuarioLogueado.Id = ((Usuario)usuario).Id;
                usuarioLogueado.Nombre = ((Usuario)usuario).Nombre;
                usuarioLogueado.NombreUsuario = ((Usuario)usuario).NombreUsuario;
                usuarioLogueado.Telefono = ((Usuario)usuario).Telefono;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al mapear el usuario logueado.");
            }
        }

        private void SetupEvents()
        {
            btnIrLevanteEntrega.Click += btnIrLevanteEntrega_Click;
            btnEntregar.Click += btnEntregar_Click;
            btnIrAltaPalet.Click += btnIrAltaPalet_Click;
            btnIrBajaPalet.Click += btnIrBajaPalet_Click;
            btnIrRegistroEntrega.Click += btnIrRegistroEntrega_Click;
            
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            try
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application);
                string json = prefs.GetString("UsuarioLogueado", "N/L");

                if (json != "N/L")
                {
                    usuarioLogueado = JsonConvert.DeserializeObject<Usuario>(json);

                    if (usuarioLogueado != null)
                    {
                        Intent intent = new Intent(this, typeof(ListarEntregasActivity));
                        intent.PutExtra("UsuarioLogueado", Newtonsoft.Json.JsonConvert.SerializeObject(usuarioLogueado));

                        StartActivity(intent);
                    }
                    else
                    {
                        Toast.MakeText(this, "No hay usuario Logueado, logueese para utilizar esta función", ToastLength.Long).Show();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private void btnIrRegistroEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application);
                string json = prefs.GetString("UsuarioLogueado", "N/L");

                if (json != "N/L")
                {
                    usuarioLogueado = JsonConvert.DeserializeObject<Usuario>(json);

                    if (usuarioLogueado != null)
                    {
                        Entrega entrega = new Entrega();

                        entrega.ClienteReceptor = null;

                        Intent intent = new Intent(this, typeof(ListadoLocalesAsignarActivity));
                        intent.PutExtra("EntregaCreacion", Newtonsoft.Json.JsonConvert.SerializeObject(entrega));
                        intent.PutExtra("Nueva", true);

                        StartActivity(intent);
                    }
                    else
                    {
                        Toast.MakeText(this, "No hay usuario Logueado, logueese para utilizar esta función", ToastLength.Long).Show();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private void btnIrLevanteEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application);
                string json = prefs.GetString("UsuarioLogueado", "N/L");

                if (json != "N/L")
                {

                    if (usuarioLogueado != null)
                    {
                        Entrega entrega = new Entrega();

                        entrega.ClienteEmisor = null;

                        Cadete cadeteLogueado = JsonConvert.DeserializeObject<Cadete>(json);

                        entrega.Cadete = cadeteLogueado.Ci;

                        Intent intent = new Intent(this, typeof(ListadoLocalesActivity));
                        intent.PutExtra("EntregaCreacion", Newtonsoft.Json.JsonConvert.SerializeObject(entrega));
                        intent.PutExtra("Nueva", true);

                        StartActivity(intent);
                    }
                    else
                    {
                        Toast.MakeText(this, "No hay usuario Logueado, logueese para utilizar esta función", ToastLength.Long).Show();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private void btnIrBajaPalet_Click(object sender, EventArgs e)
        {
            try
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application);
                string json = prefs.GetString("UsuarioLogueado", "N/L");

                if (json != "N/L")
                {
                    usuarioLogueado = JsonConvert.DeserializeObject<Usuario>(json);

                    if (usuarioLogueado != null)
                    {
                        Intent intent = new Intent(this, typeof(ListadoPaletsActivity));
                        intent.PutExtra("UsuarioLogueado", Newtonsoft.Json.JsonConvert.SerializeObject(usuarioLogueado));

                        StartActivity(intent);
                    }
                    else
                    {
                        var intent = new Intent(this, typeof(MainActivity));
                        StartActivity(intent);

                        Toast.MakeText(this, "No hay usuario Logueado, logueese para utilizar esta función", ToastLength.Long).Show();
                    }
                }
                else
                {
                    var intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);

                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private void btnIrAltaPalet_Click(object sender, EventArgs e)
        {
            try
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application);
                string json = prefs.GetString("UsuarioLogueado", "N/L");

                if (json != "N/L")
                {
                    usuarioLogueado = JsonConvert.DeserializeObject<Usuario>(json);

                    if (usuarioLogueado != null)
                    {
                        Intent intent = new Intent(this, typeof(ListadoSectoresActivity));
                        intent.PutExtra("UsuarioLogueado", Newtonsoft.Json.JsonConvert.SerializeObject(usuarioLogueado));

                        StartActivity(intent);
                    }
                    else
                    {
                        Toast.MakeText(this, "No hay usuario Logueado, logueese para utilizar esta función", ToastLength.Long).Show();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }



        private void SetupViews()
        {
            btnIrAltaPalet = FindViewById<Button>(Resource.Id.btnIrAltaPalet);
            btnIrBajaPalet = FindViewById<Button>(Resource.Id.btnIrBajaPalet);
            btnIrRegistroEntrega = FindViewById<Button>(Resource.Id.btnIrRegistroEntrega);
            btnIrLevanteEntrega = FindViewById<Button>(Resource.Id.btnIrLevanteEntrega);
            btnEntregar = FindViewById<Button>(Resource.Id.btnEntregar);

            if (VerificarSesion() == "L")
            {
                btnIrAltaPalet.Enabled = true;
                btnIrBajaPalet.Enabled = true;
                btnIrRegistroEntrega.Enabled = true;
                btnIrLevanteEntrega.Enabled = false;
                btnEntregar.Enabled = false;
            }
            else if (VerificarSesion() == "Cadete")
            {
                btnIrAltaPalet.Enabled = false;
                btnIrBajaPalet.Enabled = false;
                btnIrRegistroEntrega.Enabled = false;
                btnIrLevanteEntrega.Enabled = true;
                btnEntregar.Enabled = true;
            }
            else
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                usuarioLogueado = null;
                intent.PutExtra("UsuarioLogueado", Newtonsoft.Json.JsonConvert.SerializeObject(usuarioLogueado));

                Toast.MakeText(this, "Acceso Denegado: No tiene permisos para utilizar las funciones de esta App", ToastLength.Long).Show();

                StartActivity(intent);
            }
        }


        public string VerificarSesion()
        {
            try
            {
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                string user = prefs.GetString("UsuarioLogueado", "");

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                if (user == "")
                {
                    Toast.MakeText(this, "Acceso Denegado: No hay ningun usuario logueado", ToastLength.Long).Show();

                    
                    var intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);

                    return "";
                }
                else
                {

                    Usuario userLogueado = JsonConvert.DeserializeObject<Usuario>(user, settings);
                    

                    if (userLogueado is Administrador)
                    {
                        return ((Administrador)userLogueado).Tipo;
                    }
                    else if (userLogueado is Cadete)
                    {
                        return "Cadete";
                    }
                    else
                    {
                        return "Cliente";
                    }
                }
            }

            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: Al verificar la sesion de usuario.", ToastLength.Long).Show();

                return "";
            }

        }
    }
}