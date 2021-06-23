using ProvaPratica.Application.Domain.Convenio;
using System.Threading.Tasks;

namespace ProvaPratica.Application.Interfaces.Services
{
    public interface IConvenioService
    {
        Task<ConvenioResponse> GetConvenio();
    }
}
