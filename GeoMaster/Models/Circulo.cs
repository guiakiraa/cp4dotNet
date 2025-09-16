using System.ComponentModel.DataAnnotations;

namespace GeoMaster.Models
{
    public class Circulo : ICalculos2D, IFormaGeometrica
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O raio deve ser maior que zero.")]
        public double Raio { get; set; }

        public string TipoForma => "Circulo";

        public double CalcularArea()
        {
            return Math.PI * Math.Pow(Raio, 2);
        }

        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Raio;
        }

        public bool ValidarDimensoes()
        {
            return Raio > 0;
        }
    }
}
