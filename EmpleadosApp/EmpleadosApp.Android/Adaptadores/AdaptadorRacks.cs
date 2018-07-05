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
    class AdaptadorRacks : BaseAdapter<Rack>
    {
        private Activity contexto;
        private List<Rack> racks;

        public AdaptadorRacks(Activity contextoP, List<Rack> racksP)
        {
            contexto = contextoP;
            racks = racksP;
        }

        public override Rack this[int position] => racks[position];

        public override int Count => racks.Count;

        public override long GetItemId(int position)
        {
            return this[position].Codigo;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];

            if (convertView == null)
            {
                convertView = contexto.LayoutInflater.Inflate(Resource.Layout.RackRow, null);
            }

            bool disponibilidad = false;

            foreach (Casilla c in item.Casillas)
            {
                if (c.Palets == null || c.Palets.Count <= 0)
                {
                    disponibilidad = true;
                }
            }

            convertView.FindViewById<TextView>(Resource.Id.tvCodigo).Text = item.Codigo.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvAltura).Text = item.Altura.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvDisponibilidad).Text = disponibilidad ? "Disponible" : "No disponible";

            return convertView;
        }
    }
}