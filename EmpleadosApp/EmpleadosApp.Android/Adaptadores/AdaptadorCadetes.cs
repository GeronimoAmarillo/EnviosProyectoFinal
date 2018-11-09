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

namespace EmpleadosApp.Droid.Adaptadores
{
    class AdaptadorCadetes : BaseAdapter<Cadete>
    {
        private Activity contexto;
        private List<Cadete> cadetes;

        public AdaptadorCadetes(Activity contextoP, List<Cadete> cadetesP)
        {
            contexto = contextoP;
            cadetes = cadetesP;
        }

        public override Cadete this[int position] => cadetes[position];

        public override int Count => cadetes.Count;

        public override long GetItemId(int position)
        {
            return this[position].CiEmpleado;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];

            if (convertView == null)
            {
                convertView = contexto.LayoutInflater.Inflate(Resource.Layout.CadeteRow, null);
            }

            string vehiculo = "";

            if (item.Vehiculos != null)
            {
                if (item.Vehiculos.Count != 0)
                {
                    vehiculo = "Matricula: " + item.Vehiculos[0].Matricula + " - Marca: " + item.Vehiculos[0].Marca + " " + item.Vehiculos[0].Modelo;
                }
            }

            convertView.FindViewById<TextView>(Resource.Id.tvCedulaCadete).Text = item.CiEmpleado.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvNombreCadete).Text = item.Nombre.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvVehiculoCadete).Text = vehiculo;

            return convertView;
        }
    }
}