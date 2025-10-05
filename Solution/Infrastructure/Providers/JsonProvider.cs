using Newtonsoft.Json;

namespace Infrastructure.Providers
{
    public class JsonProvider
    {
        public static T? DeserializeObject<T>(String json) => JsonConvert.DeserializeObject<T>(json);
    }
}