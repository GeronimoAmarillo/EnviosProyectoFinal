using EntidadesCompartidasCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicaDeAppsCore
{
    public class JsonConverterVehiculos : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Vehiculo));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            if (jo.ContainsKey("MatriculaAuto"))
                return jo.ToObject<Automobil>(serializer);
            if (jo.ContainsKey("MatriculaCamion"))
                return jo.ToObject<Camion>(serializer);
            if (jo.ContainsKey("MatriculaCamioneta"))
                return jo.ToObject<Camioneta>(serializer);
            if (jo.ContainsKey("MatriculaMoto"))
                return jo.ToObject<Moto>(serializer);

            return null;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
