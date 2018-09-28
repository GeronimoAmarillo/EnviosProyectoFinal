using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using EntidadesCompartidasAndroid;
using Android.Views;
using Android.Widget;

namespace EmpleadosApp.Droid.Adaptadores
{
    class AdaptadorClientes : BaseAdapter<Cliente>
    {
        private Activity contexto;
        private List<Local> locales;

        public AdaptadorClientes(Activity contextoP, List<Cliente> clientesP)
        {
            contexto = contextoP;
            clientes = clientesP;
        }

        public override Cliente this[int position] => clientes[position];

        public override int Count => clientes.Count;

        public override long GetItemId(int position)
        {
            return this[position].RUT;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];

            if (convertView == null)
            {
                convertView = contexto.LayoutInflater.Inflate(Resource.Layout.ClienteRow, null);
            }
            

            convertView.FindViewById<TextView>(Resource.Id.tvRut).Text = item.RUT.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvNombre).Text = item.Nombre.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvTelefono).Text = item.Telefono.ToString();

            return convertView;
        }
    }
}