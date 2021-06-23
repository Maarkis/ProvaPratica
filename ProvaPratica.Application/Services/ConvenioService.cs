using Microsoft.AspNetCore.Http;
using ProvaPratica.Application.Domain.Convenio;
using ProvaPratica.Application.Interfaces.Repositories;
using ProvaPratica.Application.Interfaces.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaPratica.Application.Services
{
    public class ConvenioService : IConvenioService
    {
        private readonly IConvenioRepository _convenioRepository;

        public ConvenioService(IConvenioRepository convenioRepository)
        {
            _convenioRepository = convenioRepository;
        }

        public async Task<ConvenioResponse> GetConvenio()
        {
            var convenios = await _convenioRepository.GetConvenios();

            return new ConvenioResponse { StatusCode = StatusCodes.Status200OK, Mensagem = "Convenios obtido com sucesso.", Convenios = convenios.ToList() };            
        }
    }
}
