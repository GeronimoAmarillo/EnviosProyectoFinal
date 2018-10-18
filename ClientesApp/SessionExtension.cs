using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public static class SessionExtensions
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };
        session.SetString(key, JsonConvert.SerializeObject(value, settings));
    }

    public static T Get<T>(this ISession session, string key)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects
        };
        var value = session.GetString(key);
        return value == null ? default(T) :
                              JsonConvert.DeserializeObject<T>(value, settings);
    }
}
