using Hyperativa_API.Models;
using Hyperativa_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;

using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Hyperativa_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {
        private readonly ICartaoService _cartaoService;
        private readonly ILogApiService _logApiService;
        public CartaoController(ICartaoService cartaoService, ILogApiService logApiService)
        {
            _cartaoService = cartaoService;
            _logApiService = logApiService;
        }

        [HttpPut]
        [Route("SalvarCartao")]
        [Authorize]
        public IActionResult SalvarCartao([FromBody] CartaoInfo cartao)
        {
            try
            {
                string finalCartao = cartao.NumeroCartao.Substring(cartao.NumeroCartao.Length - 4);
                LogApi logApi = new LogApi()
                {
                    Acao = "Salvar cartão",
                    EntradaSaida = "E",
                    Login = System.Environment.UserName,
                    Detalhes = $"Cartão final {finalCartao} gravado com sucesso"
                };

                if (ModelState.IsValid)
                {

                    _cartaoService.SalvarCartao(cartao);

                    //Gravação do log
                    _logApiService.SalvarLogApi(logApi);

                    return Ok(new
                    {
                        Message = "Cartão incluído com sucesso!",
                        Success = true
                    });
                }
                else
                {
                    //Gravação do log
                    logApi.Detalhes = "Dados incompletos, nenhum cartão salvo";

                    _logApiService.SalvarLogApi(logApi);

                    return BadRequest(ModelState);
                }
            }
            catch (System.Exception ex)
            {
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }

        [HttpPost]
        [Route("CarregarLoteCartao")]
        [Authorize]
        public async Task<IActionResult> CarregarLoteCartao()
        {
            try
            {
                string mensagem = _cartaoService.CarregarLoteCartao();

                _logApiService.SalvarLogApi(new LogApi()
                {
                    Acao = "Carregar lote de cartões",
                    Login = System.Environment.UserName,
                    EntradaSaida = "S",
                    Detalhes = mensagem
                });

                return Ok(new
                {
                    Message = mensagem,
                    Success = true
                });
            }
            catch (System.Exception ex)
            {

                return Problem(statusCode: 500, detail: ex.Message);
            }
        }

        [HttpPut]
        [Route("GetCartao/{numeroCartao}")]
        [Authorize]
        public async Task<ActionResult<CartaoInfo>> GetCartao(string numeroCartao)
        {
            try
            {
                if (string.IsNullOrEmpty(numeroCartao))
                {
                    return Problem(statusCode: 500, detail: "Número do cartão deve ser fornecedo");
                }
                var cartao = _cartaoService.GetCartao(numeroCartao);

                string finalCartao = cartao.NumeroCartao.Substring(cartao.NumeroCartao.Length - 4);

                LogApi logApi = new LogApi()
                {
                    Acao = "Salvar cartão",
                    EntradaSaida = "S",
                    Login = System.Environment.UserName,
                    Detalhes = $"Consulta ao cartão final {finalCartao}"
                };

                return Ok(cartao);
            }
            catch (System.Exception ex)
            {
                return Problem(statusCode: 500, detail: ex.Message);
            }
        }
    }
}
