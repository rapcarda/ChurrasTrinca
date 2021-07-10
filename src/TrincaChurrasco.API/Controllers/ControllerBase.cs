using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace TrincaChurrasco.API.Controllers
{
    [ApiController]
    public abstract class ControllerBase : Controller
    {
        protected ICollection<string> Erros = new List<string>();

        protected ActionResult CustomResponse(object obj = null)
        {
            if (OperacaoValida()) return Ok(obj);

            if (ErroNotFound()) return NotFound();

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Erros.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var modelStateErrors = modelState.Values.SelectMany(x => x.Errors);

            foreach (var error in modelStateErrors)
            {
                AdicionarErros(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AdicionarErros(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult, object obj)
        {
            if (validationResult.IsValid) return CustomResponse(obj);

            return CustomResponse(validationResult);
        }


        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }

        protected void LimparErros()
        {
            Erros.Clear();
        }

        protected void AdicionarErros(string msgErro)
        {
            Erros.Add(msgErro);
        }

        protected void AdicionarErros(IEnumerable<string> erros)
        {
            foreach (var erro in erros)
            {
                AdicionarErros(erro);
            }
        }

        private bool ErroNotFound()
        {
            return Erros.Contains("404 - Not Found");
        }
    }
}
