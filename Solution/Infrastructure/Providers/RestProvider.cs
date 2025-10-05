using RestSharp;

namespace Infrastructure.Providers
{
    public class RestProvider
    {
        public static List<T> GetList<T>(String url, Method method)
        {
            RestClient client = new(url);
            RestRequest request = new("", method);
            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                ///Se devuelve la URL en el error ya que lo ideal seria capturar ese error, guardarlo y entregar un ID de error
                return JsonProvider.DeserializeObject<List<T>>(response.Content!) ?? throw new Exception($"Error al consultar {url}");
            }
            else
            {
                throw new Exception($"Error al consultar {url}");
            }
        }

        public static T Get<T>(String url, Method method)
        {
            RestClient client = new(url);
            RestRequest request = new("", method);
            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                ///Se devuelve la URL en el error ya que lo ideal seria capturar ese error, guardarlo y entregar un ID de error
                return JsonProvider.DeserializeObject<T>(response.Content!) ?? throw new Exception($"Error al consultar {url}");
            }
            else
            {
                throw new Exception($"Error al consultar {url}");
            }
        }
    }
}