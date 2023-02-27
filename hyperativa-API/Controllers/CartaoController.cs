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
        public CartaoController(ICartaoService cartaoService)
        {
            _cartaoService = cartaoService;
        }

        [HttpPut]
        [Route("SalvarCartao")]
        [Authorize]
        public async Task<IActionResult> SalvarCartaoAsync([FromBody] CartaoInfo cartao)
        {
            try
            {
                _cartaoService.SalvarCartao(cartao);

                return Ok(new
                {
                    Message = "Cartão incluído com sucesso!",
                    Success = true
                });
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
                var cartao = _cartaoService.GetCartao(numeroCartao);

                return Ok(cartao);
            }
            catch (System.Exception ex)
            {

                return Problem(statusCode: 500, detail: ex.Message);
            }
        }
    }
}
