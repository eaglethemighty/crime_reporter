using FluentValidation.Results;
using PoliceService.Application.Responses;

namespace PoliceService.Application.Functions.PoliceUnits.Commands.CreatePoliceUnitCommand
{
    public class CreatePoliceUnitResponse : BaseResponse
    {
        public Guid? PoliceUnitId { get; set; }
        public CreatePoliceUnitResponse(string message) : base(message)
        {
        }

        public CreatePoliceUnitResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public CreatePoliceUnitResponse(string message, bool success) : base(message, success)
        {
        }
        public CreatePoliceUnitResponse(Guid? policeUnitId)
        {
            PoliceUnitId = policeUnitId;
        }
    }
}