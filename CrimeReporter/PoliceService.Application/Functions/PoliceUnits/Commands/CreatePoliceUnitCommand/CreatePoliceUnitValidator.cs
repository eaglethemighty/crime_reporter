using FluentValidation;
using PoliceService.Domain.Entities;

namespace PoliceService.Application.Functions.PoliceUnits.Commands.CreatePoliceUnitCommand
{
    public class CreatePoliceUnitValidator : AbstractValidator<CreatePoliceUnitCommand>
    {
        public CreatePoliceUnitValidator()
        {
            RuleFor(policeUnit => policeUnit.Rank)
                .IsInEnum()
                .WithMessage("Rank value not in the range of available ranks")
                .NotEmpty()
                .WithMessage("Rank required in order to create o police unit");
        }
    }
}
