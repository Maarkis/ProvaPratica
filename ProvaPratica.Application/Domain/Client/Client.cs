using System;

namespace ProvaPratica.Application.Domain.Client
{
    public class Client
    {
        public int Prontuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Dt_Nasc { get;set; }
        public Sexo Sexo { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string UFRG { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Fone_Res { get; set; }
        public int Id_Convenio { get; set; }
        public string N_Carteirinha { get; set; }
    }

    public enum Sexo
    {
        Feminino = 0,
        Masculino = 1
    }
}
