using Newtonsoft.Json;

namespace Domain.Models
{
    public class Country
    {
        public Int32 Id { get; set; }

        [JsonProperty("alpha3Code")]
        public required String Code { get; set; }

        public required String Name { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public List<Service> Services { get; set; } = new();
    }
}