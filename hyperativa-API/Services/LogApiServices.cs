using Hyperativa_API.Models;
using Hyperativa_API.Repositories.Interfaces;
using Hyperativa_API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyperativa_API.Services
{
    public class LogApiService: ILogApiService
    {
        private readonly ILogApiRepository _logApiRepository;
        public LogApiService(ILogApiRepository LogApiRepository)
        {
            _logApiRepository = LogApiRepository;
        }

        public void SalvarLogApi(LogApi logApi)
        {            
            _logApiRepository.SalvarLogApi(logApi);
        }
    }
}
