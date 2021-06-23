using ProvaPratica.Application.Domain.Client;
using ProvaPratica.Application.Utils;
using System.Threading.Tasks;

namespace ProvaPratica.Application.Interfaces.Services
{
    public interface IClientService
    {
        Task<GetClientResponse> GetClientById(int id);
        Task<GetAllClientResponse> GetClient();
        Task<BaseResponse> Create(CreateClientRequest request);
        Task<BaseResponse> Update(UpdateClientRequest request);
        Task<bool> ExistClient(string cpf);
        Task<BaseResponse> Delete(int id);
        
    }
}
