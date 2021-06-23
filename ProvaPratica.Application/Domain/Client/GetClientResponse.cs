using ProvaPratica.Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaPratica.Application.Domain.Client
{
    public class GetClientResponse : BaseResponse 
    {
        public Client Client{ get; set; }
    }
}
