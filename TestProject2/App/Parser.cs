using Newtonsoft.Json;

namespace TestProject2.App;

public static class Parser
{

    public static List<T> DeserializeCollection<T>(this string data, Func<dynamic, T>? customMapper = null)
    {
        try
        {
            var result = JsonConvert.DeserializeObject<List<T>>(data, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error,
            });
        }
        catch
        {
            if (customMapper is null)
                throw;
        }

        var obj = JsonConvert.DeserializeObject<List<dynamic>>(data)!;
        return obj.Select(customMapper!).ToList();

    }

    public static T Deserialize<T>(this string data, Func<dynamic, T>? customMapper = null)
    {
        try
        {
            var result = JsonConvert.DeserializeObject<T>(data, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error,
            });
        }
        catch
        {
            if (customMapper is null)
                throw;
        }

        var obj = JsonConvert.DeserializeObject<dynamic>(data)!;
        return customMapper(obj);
    }
}
