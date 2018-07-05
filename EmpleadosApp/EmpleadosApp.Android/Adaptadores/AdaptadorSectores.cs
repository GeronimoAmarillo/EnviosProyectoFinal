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
    class AdaptadorSectores : BaseAdapter<Sector>
    {
        private Activity contexto;
        private List<Sector> sectores;

        public AdaptadorSectores(Activity contextoP, List<Sector> sectoresP)
        {
            contexto = contextoP;
            sectores = sectoresP;
        }

        public override Sector this[int position] => sectores[position];

        public override int Count => sectores.Count;

        public override long GetItemId(int position)
        {
            return this[position].Codigo;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];

            if (convertView == null)
            {
                convertView = contexto.LayoutInflater.Inflate(Resource.Layout.SectorRow, null);
            }

            bool disponibilidad = false;

            if(item.Racks != null || item.Racks.Count > 0)
            {
                disponibilidad = true;
            }

            convertView.FindViewById<TextView>(Resource.Id.tvCodigo).Text = item.Codigo.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvTemperatura).Text = item.Temperatura.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvDisponibilidad).Text = disponibilidad? "Disponible" : "No disponible";

            return convertView;
        }
    }
}