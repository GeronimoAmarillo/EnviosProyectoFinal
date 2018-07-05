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

namespace EmpleadosApp.Droid
{
    [Activity(Label = "Seleccion de Ubicacion")]
    public class SeleccionarUbicacionActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.SeleccionarUbicacionActivity);

            var fragmentContainer = FindViewById<FrameLayout>(Resource.Id.flSectoresContainer);
            var transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.flSectoresContainer, new ListaSectoresFragment());
            transaction.Commit();
        }
    }
}