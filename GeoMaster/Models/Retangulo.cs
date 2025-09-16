using System.ComponentModel.DataAnnotations;

namespace GeoMaster.Models
{
    public class Retangulo : ICalculos2D, IFormaGeometrica
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "A largura deve ser maior que zero.")]
        public double Largura { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "A altura deve ser maior que zero.")]
        public double Altura { get; set; }

        public string TipoForma => "Retangulo";

        public double CalcularArea()
        {
            return Largura * Altura;
        }

        public double CalcularPerimetro()
        {
            return 2 * (Largura + Altura);
        }

        public bool ValidarDimensoes()
        {
            return Largura > 0 && Altura > 0;
        }
    }
}
