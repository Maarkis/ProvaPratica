using ProvaPratica.Application.Domain.Convenio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvaPratica.Application.Interfaces.Repositories
{
    public interface IConvenioRepository
    {
        Task<IEnumerable<Convenio>> GetConvenios();
    }
}
