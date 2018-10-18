using EntidadesCompartidasCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicaDeAppsCore
{
    class JsonConverterEmpleados : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Empleado));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            if (jo.ContainsKey("CiAdministrador"))
                return jo.ToObject<Administrador>(serializer);
            if (jo.ContainsKey("CiCadete"))
                return jo.ToObject<Cadete>(serializer);

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

