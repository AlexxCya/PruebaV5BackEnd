using PruebaV5.Core.CustomEntities;

namespace PruebaV5.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data, bool _isValid)
        {
            Data = data;
            isValid = _isValid;
        }
        public T Data { get; set; }

        public Metadata Meta { get; set; }
        public bool isValid { get; set; }

    }
}
