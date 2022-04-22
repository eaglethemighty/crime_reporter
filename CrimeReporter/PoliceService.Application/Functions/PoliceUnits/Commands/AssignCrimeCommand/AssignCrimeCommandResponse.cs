using FluentValidation.Results;
using PoliceService.Application.Responses;

namespace PoliceService.Application.Functions.PoliceUnits.Commands.AssignCrimeCommand
{
    public class AssignCrimeCommandResponse : BaseResponse
    {
        public string? PoliceUnitId { get; set; }

        public AssignCrimeCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public AssignCrimeCommandResponse(string message, bool success) : base(message, success)
        {
        }
        public AssignCrimeCommandResponse(string? policeUnitId)
            :base( policeUnitId is null ? "Crime Could Not Have Been Assigned" : "Crime has been assigned successfully" )
        {
            PoliceUnitId = policeUnitId;
        }
    }
}