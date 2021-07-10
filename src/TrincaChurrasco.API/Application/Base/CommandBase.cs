using FluentValidation.Results;
using MediatR;
using System;

namespace TrincaChurrasco.API.Application.Base
{
    public abstract class CommandBase : MessageBase, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public CommandBase()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool CommandIsValid()
        {
            throw new NotImplementedException();
        }
    }
}
