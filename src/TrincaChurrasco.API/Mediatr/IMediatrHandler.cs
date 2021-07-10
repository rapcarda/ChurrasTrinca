using FluentValidation.Results;
using System.Threading.Tasks;
using TrincaChurrasco.API.Application.Base;

namespace TrincaChurrasco.API.Mediatr
{
    public interface IMediatrHandler
    {
        Task<ValidationResult> EnviarComando<T>(T comando) where T : CommandBase;
    }
}
