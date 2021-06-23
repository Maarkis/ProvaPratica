using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using ProvaPratica.Application.Domain.Client;
using ProvaPratica.Application.Interfaces.Repositories;
using ProvaPratica.Application.Interfaces.Services;
using ProvaPratica.Application.Utils;
using ProvaPratica.Application.Utils.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaPratica.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<BaseResponse> Create(CreateClientRequest request)
        {
            ValidationResult result = new CreateClientRequestValidator().Validate(request);
            if(result.IsValid)
            {
                
                if (!string.IsNullOrEmpty(request.CPF) && await ExistClient(request.CPF))
                {
                    return new BaseResponse { StatusCode = StatusCodes.Status400BadRequest, Mensagem = "Cliente já cadastrado." };
                }

                await _clientRepository.Create(request);

                return new BaseResponse { StatusCode = StatusCodes.Status201Created, Mensagem = "Cliente cadastrado com sucesso." };
            } else
            {
                return new BaseResponse { StatusCode = StatusCodes.Status400BadRequest, Mensagem = result.Errors.FirstOrDefault().ErrorMessage };
            }

        }

        public async Task<bool> ExistClient(string cpf)
        {
            Client client = await _clientRepository.GetByCPF(cpf);
            if (client == null)
            {
                return false;
            }
            return true;
        }

        public Task<BaseResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetAllClientResponse> GetClient()
        {
            IEnumerable<Client> client = await _clientRepository.GetClient();

            return new GetAllClientResponse { StatusCode = StatusCodes.Status200OK, Mensagem = "Clientes obtido com sucesso.", Clients = client.ToList() };
        }

        public async Task<GetClientResponse> GetClientById(int id)
        {
            Client client = await _clientRepository.GetById(id);          

            return new GetClientResponse { StatusCode = StatusCodes.Status200OK, Mensagem = "Cliente obtido com sucesso.", Client = client };
        }

        public async Task<BaseResponse> Update(UpdateClientRequest request)
        {
            ValidationResult result = new UpdateClientRequestValidator().Validate(request);
            if(result.IsValid)
            {
                await _clientRepository.Update(request);

                return new BaseResponse { StatusCode = StatusCodes.Status200OK, Mensagem = "Cliente atualizado com sucesso." };
            } else
            {
                return new BaseResponse { StatusCode = StatusCodes.Status400BadRequest, Mensagem = result.Errors.FirstOrDefault().ErrorMessage };
            }
            
        }
    }
}
