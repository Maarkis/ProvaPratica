using FluentValidation;
using ProvaPratica.Application.Domain.Client;
using System.Text.RegularExpressions;

namespace ProvaPratica.Application.Utils.Validation
{
    public class CreateClientRequestValidator : AbstractValidator<CreateClientRequest>
    {
        public CreateClientRequestValidator()
        {
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
                .NotNull()                
                .WithMessage("Sexo obrigátorio")
                .IsInEnum()
                .WithMessage("0 - Feminino 1 - Masculino");


            RuleFor(x => x.CPF)
                .Must(cpf => {
                    if (!string.IsNullOrEmpty(cpf))
                    {
                        Regex rx = new Regex(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}", RegexOptions.None);
                        return rx.IsMatch(cpf);
                    }
                    return true;
                })
                .WithMessage("CPF com formato inválido");

            RuleFor(x => x.RG)
                .NotNull()
                .NotEmpty()
                .WithMessage("RG obrigátorio")
                .Must(rg => {
                    Regex rx = new Regex(@"(^\d{1,2}).?(\d{3}).?(\d{3})-?(\d{1}|X|x$)", RegexOptions.None);
                    return rx.IsMatch(rg);
                })
                .WithMessage("RG com formato inválido");

            RuleFor(x => x.UFRG)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(2)
                .WithMessage("UFRG inválido");

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
