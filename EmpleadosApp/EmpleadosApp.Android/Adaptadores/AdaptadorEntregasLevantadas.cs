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
                if (item.Paquetes != null || item.Paquetes1 != null)
                {
                    if (item.Paquetes.Where(x => x.Estado == "Reclamado").Any() || item.Paquetes1.Where(x => x.Estado == "Reclamado").Any())
                    {
                        convertView = contexto.LayoutInflater.Inflate(Resource.Layout.EntregaLevantadaReclamadaRow, null);

                    }
                    else
                    {
                        convertView = contexto.LayoutInflater.Inflate(Resource.Layout.EntregaLevantadaRow, null);

                    }
                }
                else
                {
                    convertView = contexto.LayoutInflater.Inflate(Resource.Layout.EntregaLevantadaRow, null);

                }
            }
            else
            {
                if (item.Paquetes != null || item.Paquetes1 != null)
                {
                    if (item.Paquetes.Where(x => x.Estado == "Reclamado").Any() || item.Paquetes1.Where(x => x.Estado == "Reclamado").Any())
                    {
                        convertView = contexto.LayoutInflater.Inflate(Resource.Layout.EntregaLevantadaReclamadaRow, null);

                    }
                    else
                    {
                        convertView = contexto.LayoutInflater.Inflate(Resource.Layout.EntregaLevantadaRow, null);

                    }
                }
                else
                {
                    convertView = contexto.LayoutInflater.Inflate(Resource.Layout.EntregaLevantadaRow, null);

                }
            }

            if (item.Paquetes != null || item.Paquetes1 != null)
            {
                if (item.Paquetes.Where(x => x.Estado == "Reclamado").Any() || item.Paquetes1.Where(x => x.Estado == "Reclamado").Any())
                {
                    convertView.FindViewById<TextView>(Resource.Id.tvCodigoEntregaLevantadaR).Text = item.Codigo.ToString();
                    convertView.FindViewById<TextView>(Resource.Id.tvLocalEmisorEntregaLevantadaR).Text = item.Locales.Nombre.ToString();
                    convertView.FindViewById<TextView>(Resource.Id.tvDestinoEntregaLevantadaR).Text = item.Clientes1.Direccion.ToString();
                }
                else
                {
                    convertView.FindViewById<TextView>(Resource.Id.tvCodigoEntregaLevantada).Text = item.Codigo.ToString();
                    convertView.FindViewById<TextView>(Resource.Id.tvLocalEmisorEntregaLevantada).Text = item.Locales.Nombre.ToString();
                    convertView.FindViewById<TextView>(Resource.Id.tvDestinoEntregaLevantada).Text = item.Clientes1.Direccion.ToString();
                }
            }
            else
            {
                convertView.FindViewById<TextView>(Resource.Id.tvCodigoEntregaLevantada).Text = item.Codigo.ToString();
                convertView.FindViewById<TextView>(Resource.Id.tvLocalEmisorEntregaLevantada).Text = item.Locales.Nombre.ToString();
                convertView.FindViewById<TextView>(Resource.Id.tvDestinoEntregaLevantada).Text = item.Clientes1.Direccion.ToString();
            }

            return convertView;
        }
    }
}