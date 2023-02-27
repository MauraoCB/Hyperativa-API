using System;

namespace Hyperativa_API.Models
{
    public class CartaoInfo
    {
        public int Id { get; set; }

        public string NomeTitular { get; set; }
        public string NumeroCartao { get; set; }
        public string NumeroLote { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
