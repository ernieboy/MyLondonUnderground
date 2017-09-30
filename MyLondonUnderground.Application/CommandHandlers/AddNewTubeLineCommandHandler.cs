using System.Threading.Tasks;
using MediatR;
using MyLondonUnderground.Application.Commands;
using FluentValidation.Results;
using System.Collections.Generic;
using FluentValidation;

namespace MyLondonUnderground.Application.CommandHandlers
{
    public class AddNewTubeLineCommandHandler : IAsyncRequestHandler<AddNewTubeLineCommand>
    {
        private AbstractValidator<AddNewTubeLineCommand> _validator;
        public AddNewTubeLineCommandHandler(AbstractValidator<AddNewTubeLineCommand> validator)
        {
            _validator = validator;
        }
        public Task Handle(AddNewTubeLineCommand notification)
        {
            var validationResult = _validator.Validate(notification);
            bool validationSucceeded = validationResult.IsValid;
            IList<ValidationFailure> failures = validationResult.Errors;

            throw new System.NotImplementedException();
        }
    }
}
