using EntidadesCompartidasCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaDeAppsCore
{
    public class MessageConverter : JsonCreationConverter<Vehiculo>
    {
        private const string MatriculaAuto = "MatriculaAuto";
        private const string MatriculaCamion = "MatriculaCamion";
        private const string MatriculaCamioneta = "MatriculaCamioneta";
        private const string MatriculaMoto = "MatriculaMoto";

        protected override Vehiculo Create(Type objectType, JObject jObject)
        {
            if (FieldExists(MatriculaAuto, jObject))
            {
                return new Automobil();
            }
            if (FieldExists(MatriculaMoto, jObject))
            {
                return new Moto();
            }
            if (FieldExists(MatriculaCamion, jObject))
            {
                return new Camion();
            }
            if (FieldExists(MatriculaCamioneta, jObject))
            {
                return new Camioneta();
            }

            return new Vehiculo();
        }

        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }
    
}
