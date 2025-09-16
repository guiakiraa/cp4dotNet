using System.Text.Json.Serialization;

namespace GeoMaster.DTOs
{
    public class ResultadoCalculoDto
    {
        [JsonPropertyName("resultado")]
        public double Resultado { get; set; }

        [JsonPropertyName("tipoForma")]
        public string TipoForma { get; set; } = string.Empty;

        [JsonPropertyName("tipoCalculo")]
        public string TipoCalculo { get; set; } = string.Empty;
    }
}
