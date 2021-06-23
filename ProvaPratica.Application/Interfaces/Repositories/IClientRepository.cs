using ProvaPratica.Application.Domain.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaPratica.Application.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task Create(CreateClientRequest request);
        Task<IEnumerable<Client>> GetClient();
        Task Update(UpdateClientRequest request);
        Task Delete(int id);
        Task<Client> GetById(int id);        
        Task<Client> GetByCPF(string cpf);

    }
}
