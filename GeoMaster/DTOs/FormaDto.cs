using System.Text.Json.Serialization;

namespace GeoMaster.DTOs
{
    public class FormaDto
    {
        [JsonPropertyName("tipo")]
        public string Tipo { get; set; } = string.Empty;

        [JsonPropertyName("raio")]
        public double? Raio { get; set; }

        [JsonPropertyName("largura")]
        public double? Largura { get; set; }

        [JsonPropertyName("altura")]
        public double? Altura { get; set; }
    }
}
