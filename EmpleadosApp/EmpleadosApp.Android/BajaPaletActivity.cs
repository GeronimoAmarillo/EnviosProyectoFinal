using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
    [Activity(Label = "BajaPaletActivity")]
    public class BajaPaletActivity : Activity
    {
        private int id;
        private Palet paletSeleccionado;
        private TextView tvId;
        private TextView tvProducto;
        private TextView tvCantidad;
        private TextView tvPeso;
        private TextView tvCasilla;
        private TextView tvCliente;
        private Button btnBajaPallet;
        private Button btnVolver;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            VerificarSesion();

            SetContentView(Resource.Layout.BajaPaletActivity);

            try
            {

                Bundle extras = Intent.Extras;
                id = Convert.ToInt32(extras.Get("PalletSeleccionado"));

                paletSeleccionado = AsyncHelper.RunSync<Palet>(() => BuscarPalet());

                SetupViews();
                SetupEvents();

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "ERROR: " + ex.Message, ToastLength.Long).Show();
            }
        }

        private async Task<Palet> BuscarPalet()
        {
            try
            {
                //http://169.254.80.80:8080

                using (var httpClient = new HttpClient(new NativeMessageHandler()))
                {
                    var json = await httpClient.GetStringAsync(ConexionREST.ConexionPalets + "/Buscar?id=" + id);

                    Palet palet = null;

                    palet = JsonConvert.DeserializeObject<Palet>(json);

                    return palet;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al intentar buscar el pallet.");
            }
        }

        private void SetupEvents()
        {
            btnBajaPallet.Click += btnBajaPallet_Click;
            btnVolver.Click += btnVolver_Click;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ListadoPaletsActivity));

            StartActivity(intent);
        }

        private void btnBajaPallet_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {

                    using (var httpClient = new HttpClient(new NativeMessageHandler()))
                    {

                        string url = ConexionREST.ConexionPalets + "/Baja";

                        var content = new StringContent(JsonConvert.SerializeObject(paletSeleccionado), Encoding.UTF8, "application/json");

                        var result = httpClient.PostAsync(url, content).Result;

                        var contentResult = result.Content.ReadAsStringAsync();

                        if (contentResult.Result.ToUpper() == "TRUE")
                        {
                            Toast.MakeText(this, "Se dio de baja con exito el pallet.", ToastLength.Long).Show();

                            Intent intent = new Intent(this, typeof(ListadoPaletsActivity));

                            StartActivity(intent);
                        }
                        else
                        {
                            Toast.MakeText(this, "Error al dar de baja el palet.", ToastLength.Long).Show();
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
        


        private void SetupViews()
        {
            tvId = FindViewById<TextView>(Resource.Id.tvId);
            tvProducto = FindViewById<TextView>(Resource.Id.tvProducto);
            tvCantidad = FindViewById<TextView>(Resource.Id.tvCantidad);
            tvPeso = FindViewById<TextView>(Resource.Id.tvPeso);
            tvCasilla = FindViewById<TextView>(Resource.Id.tvCasilla);
            tvCliente = FindViewById<TextView>(Resource.Id.tvCliente);
            btnBajaPallet = FindViewById<Button>(Resource.Id.btnBajaPallet);
            btnVolver = FindViewById<Button>(Resource.Id.btnVolver);

            tvId.Text = paletSeleccionado.Id.ToString();
            tvProducto.Text = paletSeleccionado.Producto;
            tvCantidad.Text = paletSeleccionado.Cantidad.ToString();
            tvPeso.Text = paletSeleccionado.Peso.ToString();
            tvCasilla.Text = paletSeleccionado.Casilla.ToString();
            tvCliente.Text = paletSeleccionado.Clientes.RUT.ToString() + " - " + paletSeleccionado.Clientes.Nombre;

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