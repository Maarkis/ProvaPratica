using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaPratica.Application.Repositories
{
    public class BaseRepository
    {
        private readonly IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected string GetConnection
        {
            get { return _configuration.GetConnectionString("Connection"); }
        }
    }
}
