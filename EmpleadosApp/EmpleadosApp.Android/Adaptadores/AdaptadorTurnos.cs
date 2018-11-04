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
                hora = "0" + item.Hora.ToString()[0] + ":" + item.Hora.ToString()[1] + item.Hora.ToString()[2];
            }
            else if (item.Hora.ToString().Length == 2)
            {
                hora = "00:" + item.Hora.ToString()[0] + item.Hora.ToString()[1];
            }
            else if (item.Hora.ToString().Length == 1)
            {
                hora = "00:0" + item.Hora.ToString()[0];
            }
            else
            {
                hora = item.Hora.ToString()[0] + item.Hora.ToString()[1] + ":" + item.Hora.ToString()[2] + item.Hora.ToString()[3];
            }

            convertView.FindViewById<TextView>(Resource.Id.tvCodigoTurno).Text = item.Codigo.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvDiaTurno).Text = item.Dia.ToString();
            convertView.FindViewById<TextView>(Resource.Id.tvHoraTurno).Text = hora;

            return convertView;
        }
    }
}