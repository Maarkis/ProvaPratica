using ProvaPratica.Application.Utils;
using System.Collections.Generic;

namespace ProvaPratica.Application.Domain.Convenio
{
    public class ConvenioResponse : BaseResponse
    {
        public List<Convenio> Convenios { get; set; }
    }
}
