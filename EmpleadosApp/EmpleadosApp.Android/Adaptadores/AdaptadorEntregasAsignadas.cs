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
    class AdaptadorEntregasAsignadas : BaseAdapter<Entrega>
    {
        private Activity contexto;
        private List<Entrega> entregas;

        public AdaptadorEntregasAsignadas(Activity contextoP, List<Entrega> entregasP)
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


            convertView.FindViewById<TextView>(Resource.Id.tvCodigoEntregaAsignada).Text = item.Codigo.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvClienteEmisorEntregaAsignada).Text = item.Clientes.Nombre.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvDestinoEntregaAsignada).Text = item.Locales1.Direccion.ToString();

            return convertView;
        }
    }
}