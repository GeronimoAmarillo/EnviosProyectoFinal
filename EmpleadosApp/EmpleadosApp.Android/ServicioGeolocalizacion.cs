using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using EntidadesCompartidasAndroid;
using Newtonsoft.Json;
using Plugin.Geolocator;

namespace EmpleadosApp.Droid
{
    [Service]
    public class ServicioGeolocalizacion:Service
    {

        static readonly string TAG = "X:" + typeof(ServicioGeolocalizacion).Name;
        static readonly int TimerWait = 10000;
        Timer timer;
        DateTime startTime;
        bool isStarted = false;
        string user = "";

        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Log.Debug(TAG, $"OnStartCommand called at {startTime}, flags={flags}, startid={startId}");
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            user = prefs.GetString("UsuarioLogueado", "");

            if (isStarted)
            {

                TimeSpan runtime = DateTime.UtcNow.Subtract(startTime);
                Log.Debug(TAG, $"This service was already started, it's been running for {runtime:c}.");
            }
            else
            {
                startTime = DateTime.UtcNow;
                Log.Debug(TAG, $"Starting the service, at {startTime}.");
                timer = new Timer(HandleTimerCallback, startTime, 0, TimerWait);
                isStarted = true;
            }
            return StartCommandResult.NotSticky;
        }

        public override IBinder OnBind(Intent intent)
        {
            // This is a started service, not a bound service, so we just return null. 
            return null;
        }


        public override void OnDestroy()
        {
            timer.Dispose();
            timer = null;
            isStarted = false;

            TimeSpan runtime = DateTime.UtcNow.Subtract(startTime);
            Log.Debug(TAG, $"Simple Service destroyed at {DateTime.UtcNow} after running for {runtime:c}.");
            base.OnDestroy();
        }

        async void HandleTimerCallback(object state)
        {
            try
            {
                TimeSpan runTime = DateTime.UtcNow.Subtract(startTime);

                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(new TimeSpan(10000));

                
                Cadete cadeteLogueado = JsonConvert.DeserializeObject<Cadete>(user);

                string longitud = position.Longitude.ToString().Replace(",", ".");
                string latitud = position.Latitude.ToString().Replace(",", ".");

                cadeteLogueado.Longitud = longitud;
                cadeteLogueado.Latitud = latitud;
                string cadeteM = JsonConvert.SerializeObject(cadeteLogueado);

                
                using (var httpClient = new HttpClient())
                {
                    string url = ConexionREST.ConexionEmpleados + "/ModificarCadete";

                    var content = new StringContent(cadeteM, Encoding.UTF8, "application/json");

                    var result = httpClient.PostAsync(url, content).Result;

                    var contentResult = result.Content.ReadAsStringAsync();

                    if (contentResult.Result.ToUpper() == "TRUE")
                    {
                        Log.Debug(TAG, $"Resultado positivo");
                    }
                    else
                    {
                        Log.Debug(TAG, $"Resultado negativo");
                    }
                }



                Log.Debug(TAG, $"This service has been running for {runTime:c} (since ${state}). Latitud = " + position.Latitude.ToString() + " - Longitud = " + position.Longitude.ToString() + ". Latitud Logueada: " + cadeteLogueado.Latitud);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}