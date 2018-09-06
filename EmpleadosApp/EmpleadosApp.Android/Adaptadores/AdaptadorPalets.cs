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
    class AdaptadorPalets : BaseAdapter<Palet>
    {
        private Activity contexto;
        private List<Palet> palets;

        public AdaptadorPalets(Activity contextoP, List<Palet> paletsP)
        {
            contexto = contextoP;
            palets = paletsP;
        }

        public override Palet this[int position] => palets[position];

        public override int Count => palets.Count;

        public override long GetItemId(int position)
        {
            return this[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];

            if (convertView == null)
            {
                convertView = contexto.LayoutInflater.Inflate(Resource.Layout.PaletRow, null);
            }


            convertView.FindViewById<TextView>(Resource.Id.tvId).Text = item.Id.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvProducto).Text = item.Producto.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvCantidad).Text = item.Cantidad.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvCliente).Text = item.Clientes.RUT.ToString() + " - " + item.Clientes.Nombre;

            return convertView;
        }
    }
}