using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyperativa_API.Models
{
    public class LogApi
    {
        public DateTime DataLog
        {
            get { return DateTime.Now; } 
        }
        public string EntradaSaida
        {
            get; set;
        }
        public string Login
        {
            get; set;
        }
        public string Acao
        {
            get; set;
        }
        public string Detalhes
        {
            get; set;
        }
    }
}
