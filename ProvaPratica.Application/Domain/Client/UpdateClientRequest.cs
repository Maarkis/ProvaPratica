using System;

namespace ProvaPratica.Application.Domain.Client
{
    public class UpdateClientRequest
    {
        public int Prontuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Dt_Nasc { get; set; }
        public Sexo Sexo { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Fone_Res { get; set; }
        public int Id_Convenio { get; set; }
        public string N_Carteirinha { get; set; }
    }
}
