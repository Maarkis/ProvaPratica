using ProvaPratica.Application.Utils;
using System.Collections.Generic;

namespace ProvaPratica.Application.Domain.Client
{
    public class GetAllClientResponse : BaseResponse
    {
        public List<Client> Clients { get; set; }
    }
}
