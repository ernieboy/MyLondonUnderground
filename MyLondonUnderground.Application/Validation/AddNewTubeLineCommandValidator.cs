using FluentValidation;
using MyLondonUnderground.Application.Commands;

namespace MyLondonUnderground.Application.Validation
{
    public class AddNewTubeLineCommandValidator : AbstractValidator<AddNewTubeLineCommand>
    {
        public AddNewTubeLineCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.Description).NotEmpty();
        }
    }
}
