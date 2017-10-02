namespace Nutrimeal.Models.API
{
    public class ApiResultBase<T> : BaseResult
    {
        public T Result { get; set; }
    }
}