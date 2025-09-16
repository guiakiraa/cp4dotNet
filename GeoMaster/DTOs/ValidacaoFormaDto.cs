using System.Text.Json.Serialization;

namespace GeoMaster.DTOs
{
    public class ValidacaoFormaDto
    {
        [JsonPropertyName("formaExterna")]
        public FormaDto FormaExterna { get; set; } = new();

        [JsonPropertyName("formaInterna")]
        public FormaDto FormaInterna { get; set; } = new();
    }
}
