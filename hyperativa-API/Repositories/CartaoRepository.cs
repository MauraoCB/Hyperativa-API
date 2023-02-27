using Hyperativa_API.Infra;
using Hyperativa_API.Models;
using Hyperativa_API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyperativa_API.Repositories
{
    public class CartaoRepository: ICartaoRepository
    {
        public CartaoInfo GetCartao(string numeroCartao)
        {
            using (CartaoContext context = new())
            {
                var cartao = context.CartaoInfo
               .Where(c => c.NumeroCartao == numeroCartao).FirstOrDefault();
               
                return cartao;
            }
        }

        public void SalvarCartao(CartaoInfo cartao)
        {
            using (CartaoContext context = new())
            {
                context.Entry<CartaoInfo>(cartao).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void SalvarLogCartao()
        {
           /* using (CartaoContext context = new CartaoContext())
            {
                context.Entry<CartaoInfo>(cartao).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }*/
        }
    }
}
