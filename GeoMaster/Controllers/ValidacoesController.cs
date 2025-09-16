using GeoMaster.DTOs;
using GeoMaster.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoMaster.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class ValidacoesController : ControllerBase
    {
        private readonly ICalculadoraService _calculadoraService;

        public ValidacoesController(ICalculadoraService calculadoraService)
        {
            _calculadoraService = calculadoraService;
        }

        /// <summary>
        /// Verifica se uma forma geométrica está contida dentro de outra
        /// </summary>
        /// <param name="validacaoDto">Dados das formas externa e interna</param>
        /// <returns>True se a forma interna estiver contida na externa, False caso contrário</returns>
        /// <remarks>
        /// Exemplo de requisição para verificar se um círculo está contido em um retângulo:
        /// 
        ///     POST /api/v1/validacoes/forma-contida
        ///     {
        ///        "formaExterna": {
        ///            "tipo": "retangulo",
        ///            "largura": 10.0,
        ///            "altura": 10.0
        ///        },
        ///        "formaInterna": {
        ///            "tipo": "circulo",
        ///            "raio": 5.0
        ///        }
        ///     }
        /// </remarks>
        [HttpPost("forma-contida")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<bool> ValidarFormaContida([FromBody] ValidacaoFormaDto validacaoDto)
        {
            try
            {
                if (validacaoDto.FormaExterna == null || validacaoDto.FormaInterna == null)
                {
                    return BadRequest("Ambas as formas (externa e interna) devem ser fornecidas.");
                }

                var resultado = _calculadoraService.ValidarFormaContida(
                    validacaoDto.FormaExterna,
                    validacaoDto.FormaInterna);

                return Ok(resultado);
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
