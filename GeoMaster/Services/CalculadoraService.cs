using GeoMaster.DTOs;
using GeoMaster.Models;

namespace GeoMaster.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        public double CalcularArea(ICalculos2D forma)
        {
            return forma.CalcularArea();
        }

        public double CalcularPerimetro(ICalculos2D forma)
        {
            return forma.CalcularPerimetro();
        }

        public double CalcularVolume(ICalculos3D forma)
        {
            return forma.CalcularVolume();
        }

        public double CalcularAreaSuperficial(ICalculos3D forma)
        {
            return forma.CalcularAreaSuperficial();
        }

        public IFormaGeometrica CriarForma(FormaDto formaDto)
        {
            return formaDto.Tipo.ToLower() switch
            {
                "circulo" => new Circulo { Raio = formaDto.Raio ?? 0 },
                "retangulo" => new Retangulo
                {
                    Largura = formaDto.Largura ?? 0,
                    Altura = formaDto.Altura ?? 0
                },
                "esfera" => new Esfera { Raio = formaDto.Raio ?? 0 },
                _ => throw new ArgumentException($"Tipo de forma '{formaDto.Tipo}' não suportado.")
            };
        }

        public bool ValidarFormaContida(FormaDto formaExterna, FormaDto formaInterna)
        {
            var externa = CriarForma(formaExterna);
            var interna = CriarForma(formaInterna);

            // Validar se as formas são válidas
            if (!externa.ValidarDimensoes() || !interna.ValidarDimensoes())
                return false;

            return (externa, interna) switch
            {
                (Retangulo ret, Circulo circ) => ValidarCirculoEmRetangulo(ret, circ),
                (Circulo circExt, Retangulo retInt) => ValidarRetanguloEmCirculo(circExt, retInt),
                (Circulo circExt, Circulo circInt) => ValidarCirculoEmCirculo(circExt, circInt),
                (Retangulo retExt, Retangulo retInt) => ValidarRetanguloEmRetangulo(retExt, retInt),
                _ => false
            };
        }

        private bool ValidarCirculoEmRetangulo(Retangulo retangulo, Circulo circulo)
        {
            return circulo.Raio * 2 <= retangulo.Largura && circulo.Raio * 2 <= retangulo.Altura;
        }

        private bool ValidarRetanguloEmCirculo(Circulo circulo, Retangulo retangulo)
        {
            double diagonal = Math.Sqrt(Math.Pow(retangulo.Largura, 2) + Math.Pow(retangulo.Altura, 2));
            return diagonal <= circulo.Raio * 2;
        }

        private bool ValidarCirculoEmCirculo(Circulo externo, Circulo interno)
        {
            return interno.Raio <= externo.Raio;
        }

        private bool ValidarRetanguloEmRetangulo(Retangulo externo, Retangulo interno)
        {
            return interno.Largura <= externo.Largura && interno.Altura <= externo.Altura;
        }
    }
}
