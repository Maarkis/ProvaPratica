using Dapper;
using Microsoft.Extensions.Configuration;
using ProvaPratica.Application.Domain.Convenio;
using ProvaPratica.Application.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProvaPratica.Application.Repositories
{
    public class ConvenioRepository : BaseRepository, IConvenioRepository
    {
        public ConvenioRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Convenio>> GetConvenios()
        {
            string query = @"SELECT 
                                ID_Convenio,
                                Empresa                                                             
                            FROM Convenios";

            using var con = new SqlConnection(GetConnection);

            await con.OpenAsync();

            return await con.QueryAsync<Convenio>(query);
        }
    }
}
