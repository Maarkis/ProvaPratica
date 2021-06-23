using Dapper;
using Microsoft.Extensions.Configuration;
using ProvaPratica.Application.Domain;
using ProvaPratica.Application.Domain.Client;
using ProvaPratica.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProvaPratica.Application.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        
        public ClientRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Create(CreateClientRequest request)
        {
            //string query = @"INSERT INTO Clientes
            //                    (Nome, Sobrenome, Dt_Nasc, RG,
            //                     UFRG, CPF, Sexo, Fone_Res, Email,
            //                     Celular) 
            //               VALUES
            //                    (@Nome, @Sobrenome, @Dt_Nasc, @RG,
            //                     @UFRG, @CPF, @Sexo, @Fone_Res, @Email,
            //                     @Celular)";

            string query = @"INSERT INTO Clientes
                                (Nome, Sobrenome, Dt_Nasc, RG,
                                 UFRG, CPF, Sexo, Fone_Res, Email,
                                 Celular, ID_Convenio, N_Carteirinha) 
                           VALUES
                                (@Nome, @Sobrenome, @Dt_Nasc, @RG,
                                 @UFRG, @CPF, @Sexo, @Fone_Res, @Email,
                                 @Celular, @ID_Convenio, @N_Carteirinha)";


            using var con = new SqlConnection(GetConnection);

            await con.OpenAsync();

            await con.ExecuteAsync(query, new {                 
                request.Nome,
                request.Sobrenome, 
                request.Dt_Nasc,
                request.RG,
                request.UFRG,
                request.CPF,
                request.Sexo,
                request.Fone_Res,
                request.Email,     
                request.Celular,
                request.Id_Convenio,
                request.N_Carteirinha
            });
        }
        public async Task<Client> GetByCPF(string cpf)
        {
            string query = @"SELECT 
                                Prontuario,
                                Nome,
                                Sobrenome,
                                Dt_Nasc,
                                RG,
                                UFRG,
                                CPF,
                                Sexo,
                                Fone_Res,
                                Email,
                                Celular,
                                Nome_Mae,
                                ID_Convenio,
                                N_Carteirinha                                                                
                            FROM Clientes
                            WHERE
                                CPF = @CPF";

            using var con = new SqlConnection(GetConnection);

            await con.OpenAsync();

            return await con.QueryFirstOrDefaultAsync<Client>(query, new { CPF = cpf });
        }
        public async Task<Client> GetById(int id)
        {
            string query = @"SELECT 
                                Prontuario,
                                Nome,
                                Sobrenome,
                                Dt_Nasc,
                                RG,
                                UFRG,
                                CPF,
                                Sexo,
                                Fone_Res,
                                Email,
                                Celular,
                                Nome_Mae,
                                ID_Convenio,
                                N_Carteirinha                                                                
                            FROM Clientes
                            WHERE
                                Prontuario = @Prontuario";

            using var con = new SqlConnection(GetConnection);

            await con.OpenAsync();

            return await con.QueryFirstOrDefaultAsync<Client>(query, new { Prontuario = id });
        }
        public async Task<IEnumerable<Client>> GetClient()
        {
            string query = @"SELECT 
                                Prontuario,
                                Nome,
                                Sobrenome,
                                Dt_Nasc,
                                RG,
                                UFRG,
                                CPF,
                                Sexo,
                                Fone_Res,
                                Email,
                                Celular,
                                Nome_Mae,
                                ID_Convenio,
                                N_Carteirinha                                                                
                            FROM Clientes";

            using var con = new SqlConnection(GetConnection);

            await con.OpenAsync();

            return await con.QueryAsync<Client>(query);
        }
        public async Task Update(UpdateClientRequest request)
        {
            string query = @"UPDATE Clientes
                                SET
                                    Nome = @Nome,
                                    Sobrenome = @Sobrenome,
                                    Dt_Nasc = @Dt_Nasc, 
                                    Sexo = @Sexo,
                                    Fone_Res = @Fone_Res,
                                    Email = @Email,
                                    Celular = @Celular,                                    
                                    ID_Convenio = @Id_Convenio,
                                    N_Carteirinha = @N_Carteirinha
                                WHERE
                                    Prontuario = @Prontuario";

            using var con = new SqlConnection(GetConnection);

            await con.OpenAsync();

            await con.ExecuteAsync(query, new
            {
                request.Prontuario,
                request.Nome,
                request.Sobrenome,
                request.Dt_Nasc,
                request.Sexo,
                request.Fone_Res,
                request.Email,
                request.Celular,
                request.Id_Convenio,
                request.N_Carteirinha
            });

        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
