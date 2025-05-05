namespace Vives.Services.Model
{
    public class ServiceResult<T> : ServiceResult
        where T : class
    {
        public T? Data { get; set; }
    }
}
