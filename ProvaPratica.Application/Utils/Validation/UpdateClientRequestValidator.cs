using FluentValidation;
using ProvaPratica.Application.Domain.Client;
using System.Text.RegularExpressions;

namespace ProvaPratica.Application.Utils.Validation
{
    public class UpdateClientRequestValidator : AbstractValidator<UpdateClientRequest>
    {
        public UpdateClientRequestValidator()
        {
            RuleFor(f => f.Prontuario)
                .NotNull()
               .NotEmpty()
               .WithMessage("Prontuário obrigátorio");

            RuleFor(f => f.Nome)
               .NotNull()
               .NotEmpty()
               .WithMessage("Nome obrigátorio");

            RuleFor(f => f.Sobrenome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Sobrenome obrigátorio");

            RuleFor(f => f.Dt_Nasc)
                .NotNull()
                .WithMessage("Data de nascimento obrigátorio");

            RuleFor(f => f.Sexo)
                .IsInEnum()
                .WithMessage("0 - Feminino 1 - Masculino");


            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("E-mail obrigátorio")
                .EmailAddress()
                .WithMessage("E-mail inválido");

            RuleFor(x => x.Celular)
                .NotNull()
                .NotEmpty()
                .WithMessage("Celular obrigátorio")
                .Must(celular => {
                    Regex rx = new Regex(@"(\(?\d{2}\)?\s)?(\d{4,5}\-\d{4})", RegexOptions.None);
                    return rx.IsMatch(celular);
                })
                .WithMessage("Celular inválido");

            RuleFor(x => x.Celular)
                .NotNull()
                .NotEmpty()
                .WithMessage("Telefone Residencial obrigátorio")
                .Must(celular => {
                    Regex rx = new Regex(@"(\(?\d{2}\)?\s)?(\d{4,5}\-\d{4})", RegexOptions.None);
                    return rx.IsMatch(celular);
                })
                .WithMessage("Telefone Residencial inválido");

            RuleFor(x => x.Id_Convenio)
                .NotEmpty()
                .NotNull()
                .WithMessage("Convenio obrigátorio");

            RuleFor(x => x.N_Carteirinha)
                .NotEmpty()
                .NotNull()
                .WithMessage("Número da carteirinha obrigátorio");
        }
    }
}
