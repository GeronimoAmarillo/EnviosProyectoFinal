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
    class AdaptadorPaquetes:BaseAdapter<Paquete>
    {
        private Activity contexto;
        private List<Paquete> paquetes;

        public AdaptadorPaquetes(Activity contextoP, List<Paquete> paquetesP)
        {
            contexto = contextoP;
            paquetes = paquetesP;
        }

        public override Paquete this[int position] => paquetes[position];

        public override int Count => paquetes.Count;

        public override long GetItemId(int position)
        {
            return this[position].NumReferencia;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];

            if (convertView == null)
            {
                if (item.Estado.ToLower() == "reclamado")
                {
                    convertView = contexto.LayoutInflater.Inflate(Resource.Layout.PaqueteReclamadoRow, null);
                }
                else
                {
                    convertView = contexto.LayoutInflater.Inflate(Resource.Layout.PaqueteRow, null);
                }
                
            }


            convertView.FindViewById<TextView>(Resource.Id.tvNumReferencia).Text = item.NumReferencia.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvEstado).Text = item.Estado.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvCliente).Text = item.Cliente.ToString();

            return convertView;
        }
    }
}