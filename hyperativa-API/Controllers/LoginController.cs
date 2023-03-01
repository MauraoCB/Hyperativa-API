using Hyperativa_API.Models;
using Hyperativa_API.Repositories;
using Hyperativa_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Hyperativa_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpGet]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(string usuario, string senha)
        {
            // Recupera o usuário
            var usarioLogado = UsuarioRepository.GetUsuario(usuario, senha);

            // Verifica se o usuário existe
            if (usarioLogado == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var tokenGerado = TokenService.GetToken(usarioLogado);

            // Oculta a senha para não retornar ao frontend
            usarioLogado.Senha = "";

            // Retorna os dados
            return new
            {
                user = usarioLogado,
                token = tokenGerado
            };
        }
    }
}
