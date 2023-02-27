using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hyperativa_API.Models;

namespace Hyperativa_API.Services.Interfaces
{
    public interface ICartaoService
    {
        void SalvarCartao(CartaoInfo cartao);
        string CarregarLoteCartao();
        CartaoInfo GetCartao(string numeroCartao);
    }
}
