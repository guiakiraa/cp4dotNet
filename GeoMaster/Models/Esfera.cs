using System.ComponentModel.DataAnnotations;

namespace GeoMaster.Models
{
    public class Esfera : ICalculos3D, IFormaGeometrica
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O raio deve ser maior que zero.")]
        public double Raio { get; set; }

        public string TipoForma => "Esfera";

        public double CalcularVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Raio, 3);
        }

        public double CalcularAreaSuperficial()
        {
            return 4 * Math.PI * Math.Pow(Raio, 2);
        }

        public bool ValidarDimensoes()
        {
            return Raio > 0;
        }
    }
}
