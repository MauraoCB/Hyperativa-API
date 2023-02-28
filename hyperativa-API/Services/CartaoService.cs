using Hyperativa_API.Models;
using Hyperativa_API.Repositories.Interfaces;
using Hyperativa_API.Services.Interfaces;
using Hyperativa_API.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Hyperativa_API.Services
{
    public class CartaoService: ICartaoService
    {

        private readonly ICartaoRepository _cartaoRepository;
        public CartaoService(ICartaoRepository cartaoRepository)
        {
            _cartaoRepository = cartaoRepository;
        }

        public string CarregarLoteCartao()
        {
            int quantidadeRegistros=0;
            int totalProcessados=0;

            

            string nomeTitular;
            try
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var lotePath = config.GetValue<string>("CartaoLotePath");

                if (File.Exists(lotePath + "DESAFIO-HYPERATIVA.txt"))
                {
                    string[] linhasCartao = File.ReadAllLines(lotePath + "DESAFIO-HYPERATIVA.txt");
                    string linha = linhasCartao[0];
                    nomeTitular = linha.Substring(0, 29);
                    DateTime dataInclusao = new DateTime(Convert.ToInt16(linha.Substring(29, 4)), Convert.ToInt16(linha.Substring(33, 2)), Convert.ToInt16(linha.Substring(35, 2)));
                    string numeroLote = linha.Substring(37, 8);
                    quantidadeRegistros = Convert.ToInt16(linha.Substring(45, 5));

                    for (int i = 1; i < linhasCartao.Length; i++)
                    {
                        if (linhasCartao[i].Substring(0,1) == "C")
                        {
                            try
                            {
                                CartaoInfo cartao = new CartaoInfo()
                                {
                                    DataInclusao = dataInclusao,
                                    NomeTitular = Cryptography.Encrypt(nomeTitular),
                                    NumeroCartao = Cryptography.Encrypt(linhasCartao[i].Substring(7,19)),
                                    NumeroLote = numeroLote
                                };

                                SalvarCartao(cartao);
                                totalProcessados++;
                            }
                            catch (Exception)
                            {
                                
                            }
                        }
                    }

                }

                return $"{totalProcessados} registros processados de um total de {quantidadeRegistros}";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public CartaoInfo GetCartao(string numeroCartao)
        {
            var cartao = _cartaoRepository.GetCartao(numeroCartao);

            cartao.NumeroCartao = Cryptography.Decrypt(cartao.NumeroCartao);
            cartao.NomeTitular = Cryptography.Decrypt(cartao.NomeTitular);

            return cartao;
        }

        public  void SalvarCartao(CartaoInfo cartao)
        {
            if (cartao.DataInclusao == DateTime.MinValue)
            {
                cartao.DataInclusao = DateTime.Now;
            }

            cartao.NumeroCartao = Cryptography.Encrypt(cartao.NumeroCartao);
            cartao.NomeTitular = Cryptography.Encrypt(cartao.NomeTitular);
             
            _cartaoRepository.SalvarCartao(cartao);
        }
         
        private void SalvarLog()
        {            
            
        }
    }
}
