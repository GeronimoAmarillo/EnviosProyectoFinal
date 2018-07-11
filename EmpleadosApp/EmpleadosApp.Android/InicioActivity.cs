using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EntidadesCompartidasAndroid;

namespace EmpleadosApp.Droid
{
    [Activity(Label = "Inicio")]
    public class InicioActivity : Activity
    {
        Button btnIrAltaPalet;
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
                string usuarioL = extras.GetString("UsuarioLogueado");

                usuarioLogueado = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(usuarioL);
                
                
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
        }

        private void btnIrAltaPalet_Click(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private void SetupViews()
        {
            btnIrAltaPalet = FindViewById<Button>(Resource.Id.btnIrAltaPalet);
        }
    }
}