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
    class AdaptadorTurnos: BaseAdapter<Turno>
    {
        private Activity contexto;
        private List<Turno> turnos;

        public AdaptadorTurnos(Activity contextoP, List<Turno> turnosP)
        {
            contexto = contextoP;
            turnos = turnosP;
        }

        public override Turno this[int position] => turnos[position];

        public override int Count => turnos.Count;

        public override long GetItemId(int position)
        {
            return this[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this[position];

            if (convertView == null)
            {
                convertView = contexto.LayoutInflater.Inflate(Resource.Layout.TurnoRow, null);
            }

            string hora = "";

            if (item.Hora.ToString().Length == 3)
            {
                string horastring = item.Hora.ToString();
                hora = "0" + horastring.Substring(0,1) + ":" + horastring.Substring(1,1)+ horastring.Substring(2,1);
            }
            else if (item.Hora.ToString().Length == 2)
            {
                string horastring = item.Hora.ToString();
                hora = "00:" + horastring.Substring(0, 1) + horastring.Substring(1, 1);
            }
            else if (item.Hora.ToString().Length == 1)
            {
                string horastring = item.Hora.ToString();
                hora = "00:0" + horastring.Substring(0, 1);
            }
            else
            {
                string horastring = item.Hora.ToString();
                hora = horastring.Substring(0, 1) + horastring.Substring(1, 1) + ":" + horastring.Substring(2, 1) + horastring.Substring(3, 1);
            }

            convertView.FindViewById<TextView>(Resource.Id.tvCodigoTurno).Text = item.Codigo.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvDiaTurno).Text = item.Dia.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvHoraTurno).Text = hora;

            return convertView;
        }
    }
}