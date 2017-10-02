namespace Nutrimeal.Models.API
{
    public class ErrorActionResult<T>
    {
        public T ErrorType { get; set; }
        public string Message { get; set; }
    }
}