using Hyperativa_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyperativa_API.Repositories
{
    //Não será implementada a persistência e recuperação do usuário no banco de dados
    public class UsuarioRepository
    {
        public static Usuario GetUsuario(string login, string senha)
        {
            var usuarios = new List<Usuario>();

            usuarios.Add(new Usuario { Login = "userHyperativa", Senha = "Hyp3@tiva" });

            return usuarios.Where(u => u.Login == login && u.Senha == senha).FirstOrDefault();
        }
    }
}
