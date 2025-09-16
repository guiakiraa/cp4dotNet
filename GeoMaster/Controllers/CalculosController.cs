using GeoMaster.DTOs;
using GeoMaster.Models;
using GeoMaster.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoMaster.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class CalculosController : ControllerBase
    {
        private readonly ICalculadoraService _calculadoraService;

        public CalculosController(ICalculadoraService calculadoraService)
        {
            _calculadoraService = calculadoraService;
        }

        /// <summary>
        /// Calcula a área de uma forma geométrica 2D
        /// </summary>
        /// <param name="formaDto">Dados da forma geométrica</param>
        /// <returns>Resultado do cálculo da área</returns>
        /// <remarks>
        /// Exemplo de requisição para calcular área de um círculo:
        /// 
        ///     POST /api/v1/calculos/area
        ///     {
        ///        "tipo": "circulo",
        ///        "raio": 5.0
        ///     }
        /// 
        /// Exemplo para retângulo:
        /// 
        ///     POST /api/v1/calculos/area
        ///     {
        ///        "tipo": "retangulo",
        ///        "largura": 10.0,
        ///        "altura": 5.0
        ///     }
        /// </remarks>
        [HttpPost("area")]
        [ProducesResponseType(typeof(ResultadoCalculoDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<ResultadoCalculoDto> CalcularArea([FromBody] FormaDto formaDto)
        {
            try
            {
                var forma = _calculadoraService.CriarForma(formaDto);

                if (forma is not ICalculos2D forma2D)
                {
                    return BadRequest($"A forma '{forma.TipoForma}' não suporta cálculo de área 2D.");
                }

                if (!forma.ValidarDimensoes())
                {
                    return BadRequest("Dimensões inválidas. Todos os valores devem ser maiores que zero.");
                }

                var resultado = _calculadoraService.CalcularArea(forma2D);

                return Ok(new ResultadoCalculoDto
                {
                    Resultado = Math.Round(resultado, 4),
                    TipoForma = forma.TipoForma,
                    TipoCalculo = "Area"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        /// <summary>
        /// Calcula o perímetro de uma forma geométrica 2D
        /// </summary>
        /// <param name="formaDto">Dados da forma geométrica</param>
        /// <returns>Resultado do cálculo do perímetro</returns>
        [HttpPost("perimetro")]
        [ProducesResponseType(typeof(ResultadoCalculoDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<ResultadoCalculoDto> CalcularPerimetro([FromBody] FormaDto formaDto)
        {
            try
            {
                var forma = _calculadoraService.CriarForma(formaDto);

                if (forma is not ICalculos2D forma2D)
                {
                    return BadRequest($"A forma '{forma.TipoForma}' não suporta cálculo de perímetro.");
                }

                if (!forma.ValidarDimensoes())
                {
                    return BadRequest("Dimensões inválidas. Todos os valores devem ser maiores que zero.");
                }

                var resultado = _calculadoraService.CalcularPerimetro(forma2D);

                return Ok(new ResultadoCalculoDto
                {
                    Resultado = Math.Round(resultado, 4),
                    TipoForma = forma.TipoForma,
                    TipoCalculo = "Perimetro"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        /// <summary>
        /// Calcula o volume de uma forma geométrica 3D
        /// </summary>
        /// <param name="formaDto">Dados da forma geométrica</param>
        /// <returns>Resultado do cálculo do volume</returns>
        /// <remarks>
        /// Exemplo de requisição para calcular volume de uma esfera:
        /// 
        ///     POST /api/v1/calculos/volume
        ///     {
        ///        "tipo": "esfera",
        ///        "raio": 3.0
        ///     }
        /// </remarks>
        [HttpPost("volume")]
        [ProducesResponseType(typeof(ResultadoCalculoDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<ResultadoCalculoDto> CalcularVolume([FromBody] FormaDto formaDto)
        {
            try
            {
                var forma = _calculadoraService.CriarForma(formaDto);

                if (forma is not ICalculos3D forma3D)
                {
                    return BadRequest($"A forma '{forma.TipoForma}' não suporta cálculo de volume.");
                }

                if (!forma.ValidarDimensoes())
                {
                    return BadRequest("Dimensões inválidas. Todos os valores devem ser maiores que zero.");
                }

                var resultado = _calculadoraService.CalcularVolume(forma3D);

                return Ok(new ResultadoCalculoDto
                {
                    Resultado = Math.Round(resultado, 4),
                    TipoForma = forma.TipoForma,
                    TipoCalculo = "Volume"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        /// <summary>
        /// Calcula a área superficial de uma forma geométrica 3D
        /// </summary>
        /// <param name="formaDto">Dados da forma geométrica</param>
        /// <returns>Resultado do cálculo da área superficial</returns>
        [HttpPost("area-superficial")]
        [ProducesResponseType(typeof(ResultadoCalculoDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<ResultadoCalculoDto> CalcularAreaSuperficial([FromBody] FormaDto formaDto)
        {
            try
            {
                var forma = _calculadoraService.CriarForma(formaDto);

                if (forma is not ICalculos3D forma3D)
                {
                    return BadRequest($"A forma '{forma.TipoForma}' não suporta cálculo de área superficial.");
                }

                if (!forma.ValidarDimensoes())
                {
                    return BadRequest("Dimensões inválidas. Todos os valores devem ser maiores que zero.");
                }

                var resultado = _calculadoraService.CalcularAreaSuperficial(forma3D);

                return Ok(new ResultadoCalculoDto
                {
                    Resultado = Math.Round(resultado, 4),
                    TipoForma = forma.TipoForma,
                    TipoCalculo = "AreaSuperficial"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
    }
}
