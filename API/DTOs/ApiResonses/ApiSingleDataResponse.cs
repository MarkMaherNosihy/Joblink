 

namespace API.DTOs.ApiResponses
{
    public class ApiSingleDataResponse<T>: ApiResponseBase
    where T : class
    {
        public required T Data { get; set; }
    }
}