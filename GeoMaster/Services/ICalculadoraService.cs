using GeoMaster.DTOs;
using GeoMaster.Models;

namespace GeoMaster.Services
{
    public interface ICalculadoraService
    {
        double CalcularArea(ICalculos2D forma);
        double CalcularPerimetro(ICalculos2D forma);
        double CalcularVolume(ICalculos3D forma);
        double CalcularAreaSuperficial(ICalculos3D forma);
        IFormaGeometrica CriarForma(FormaDto formaDto);
        bool ValidarFormaContida(FormaDto formaExterna, FormaDto formaInterna);
    }
}
