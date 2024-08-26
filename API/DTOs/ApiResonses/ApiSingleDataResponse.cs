 

namespace API.DTOs.ApiResponses
{
    public class ApiSingleDataResponse<T>: ApiResponseBase<T> 
    where T : class
    {
        public required T Data { get; set; }
    }
}