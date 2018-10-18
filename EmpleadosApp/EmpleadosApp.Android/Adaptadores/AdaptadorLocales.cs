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
    class AdaptadorLocales: BaseAdapter<Local>
    {
        private Activity contexto;
        private List<Local> locales;

        public AdaptadorLocales(Activity contextoP, List<Local> localesP)
        {
            contexto = contextoP;
            locales = localesP;
        }

        public override Local this[int position] => locales[position];

        public override int Count => locales.Count;

        public override long GetItemId(int position)
        {
            return this[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];

            if (convertView == null)
            {
                convertView = contexto.LayoutInflater.Inflate(Resource.Layout.LocalRow, null);
            }


            convertView.FindViewById<TextView>(Resource.Id.tvIdLocal).Text = item.Id.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvNombreLocal).Text = item.Nombre.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvDireccionLocal).Text = item.Direccion.ToString();

            return convertView;
        }
    }
}