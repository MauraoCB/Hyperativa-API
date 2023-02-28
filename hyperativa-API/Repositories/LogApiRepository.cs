using Hyperativa_API.Infra;
using Hyperativa_API.Models;
using Hyperativa_API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyperativa_API.Repositories
{
    public class LogApiRepository: ILogApiRepository
    {
        public void SalvarLogApi(LogApi logApi)
        {
            using (CartaoContext context = new())
            {
                context.Entry<LogApi>(logApi).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
