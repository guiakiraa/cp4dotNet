namespace GeoMaster.Models
{
    /// <summary>
    /// Interface base para todas as formas geométricas
    /// </summary>
    public interface IFormaGeometrica
    {
        string TipoForma { get; }
        bool ValidarDimensoes();
    }
}
