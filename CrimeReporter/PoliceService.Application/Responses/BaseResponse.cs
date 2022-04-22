using FluentValidation.Results;

namespace PoliceService.Application.Responses
{
    public class BaseResponse
    {
        public ResponseStatus Status { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "Success";
        public List<string> ValidationErrors { get; set; }
        public BaseResponse(string message)
        {
            ValidationErrors = new List<string>();
            Message = message;
        }

        public BaseResponse(string message, bool success)
            : this(message)
        {
            Success = success;
        }

        public BaseResponse(ValidationResult validationResult)
        {
            ValidationErrors = new List<String>();
            Success = validationResult.Errors.Count < 0;
            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }
            Message = "Problems during data validation";
        }

        public BaseResponse()
        {
            ValidationErrors = new();
            Success = true;
        }
    }

    public enum ResponseStatus
    {
        Success = 0,
        NotFound = 1,
        BadQuery = 2,
        ValidationError = 3
    }
}
