using System;
using System.ComponentModel.DataAnnotations;

namespace Hyperativa_API.Models
{
    public class CartaoInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome do titular é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome do titular não pode exceder 50 caracteres")]
        public string NomeTitular { get; set; }
        [Required(ErrorMessage = "Número do cartão é obrigatório")]
        [StringLength(50, ErrorMessage = "O número do cartão não pode exceder 18 caracteres")]
        public string NumeroCartao { get; set; }
        public string NumeroLote { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
