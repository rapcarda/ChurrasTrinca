using FluentValidation;
using System;
using TrincaChurrasco.API.Application.Base;

namespace TrincaChurrasco.API.Application.Commands.CriarChurrasco
{
    public class CriarChurrascoCommand : CommandBase
    {
        public DateTime DataHora { get; private set; }
        public string Descricao { get; private set; }
        public string Observacao { get; private set; }
        public decimal ValorComBebida { get; private set; }
        public decimal ValorSemBebida { get; private set; }

        public CriarChurrascoCommand(DateTime dataHora, string descricao, string observacao, decimal valorComBebida, decimal valorSemBebida)
        {
            DataHora = dataHora;
            Descricao = descricao;
            Observacao = observacao;
            ValorComBebida = valorComBebida;
            ValorSemBebida = valorSemBebida;
        }

        public override bool CommandIsValid()
        {
            ValidationResult = new CriarChurrascoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CriarChurrascoCommandValidation : AbstractValidator<CriarChurrascoCommand>
    {
        public CriarChurrascoCommandValidation()
        {
            RuleFor(c => c.DataHora)
                .NotNull()
                .GreaterThan(DateTime.Now)
                .WithMessage("Data/Hora do churrasco inválida.");

            RuleFor(c => c.Descricao)
                .NotNull()
                .WithMessage("Descrição inválida.");

            RuleFor(c => c.ValorComBebida)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Valor com bebida sugerido inválido.");

            RuleFor(c => c.ValorSemBebida)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Valor sem bebida sugerido inválido.");
        }
    }
}
