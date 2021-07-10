using FluentValidation.Results;
using System.Threading.Tasks;
using TrincaChurrasco.Domain.Core.Repository;

namespace TrincaChurrasco.API.Application.Base
{
    public abstract class CommandHandlerBase
    {
        public ValidationResult ValidationResult { get; set; }

        public CommandHandlerBase()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork unitOfWork)
        {
            if (!await unitOfWork.Commit()) AdicionarErro("Houve um erro ao persistir os dados.");
            return ValidationResult;
        }

    }
}
