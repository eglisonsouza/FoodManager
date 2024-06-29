namespace GetFood.Models
{
    public class CustomResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string[]? Errors { get; set; }
        public T? Data { get; set; }
    }
}
