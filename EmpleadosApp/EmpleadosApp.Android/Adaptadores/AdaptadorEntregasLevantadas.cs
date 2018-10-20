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
    class AdaptadorEntregasLevantadas : BaseAdapter<Entrega>
    {
        private Activity contexto;
        private List<Entrega> entregas;

        public AdaptadorEntregasLevantadas(Activity contextoP, List<Entrega> entregasP)
        {
            contexto = contextoP;
            entregas = entregasP;
        }

        public override Entrega this[int position] => entregas[position];

        public override int Count => entregas.Count;

        public override long GetItemId(int position)
        {
            return this[position].Codigo;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];

            if (convertView == null)
            {
                convertView = contexto.LayoutInflater.Inflate(Resource.Layout.ClienteRow, null);
            }


            convertView.FindViewById<TextView>(Resource.Id.tvCodigoEntregaLevantada).Text = item.Codigo.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvLocalEmisorEntregaLevantada).Text = item.Locales.Nombre.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvDestinoEntregaLevantada).Text = item.Clientes1.Direccion.ToString();

            return convertView;
        }
    }
}