using Hyperativa_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyperativa_API.Repositories.Interfaces
{
   public  interface ILogApiRepository
    {
        public void SalvarLogApi(LogApi logApi);
    }
}
