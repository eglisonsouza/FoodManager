namespace FoodManager.Core.Mediator.Results
{
    public class CustomResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string[]? Errors { get; set; }
        public object? Data { get; set; }

        public static CustomResult Success(string message, object? data = null)
        {
            return new CustomResult { IsSuccess = true, Message = message, Data = data };
        }

        public static CustomResult Fail(string message, string[]? errors = null)
        {
            return new CustomResult { IsSuccess = false, Message = message, Errors = errors };
        }
    }
}
