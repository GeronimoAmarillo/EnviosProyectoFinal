using System;
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
        Button btnIrLevanteEntrega;
        Button btnIrRegistroEntrega;
        Usuario usuarioLogueado;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            try
            {
                SetContentView(Resource.Layout.InicioActivity);

                SetupViews();
                SetupEvents();

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
                }
                else
                {
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application);
                    string json = prefs.GetString("UsuarioLogueado", "N/L");

                    if (json != "N/L")
                    {
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
            btnIrAltaPalet.Click += btnIrAltaPalet_Click;
            btnIrBajaPalet.Click += btnIrBajaPalet_Click;
            btnIrLevanteEntrega.Click += btnIrLevanteEntrega_Click;
            btnIrRegistroEntrega.Click += btnIrRegistroEntrega_Click;
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
                    usuarioLogueado = JsonConvert.DeserializeObject<Usuario>(json);

                    if (usuarioLogueado != null)
                    {
                        Entrega entrega = new Entrega();

                        entrega.ClienteEmisor = null;

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
            btnIrLevanteEntrega = FindViewById<Button>(Resource.Id.btnIrLevanteEntrega);
            btnIrBajaPalet = FindViewById<Button>(Resource.Id.btnIrBajaPalet);
            btnIrRegistroEntrega = FindViewById<Button>(Resource.Id.btnIrRegistroEntrega);
        }
    }
}