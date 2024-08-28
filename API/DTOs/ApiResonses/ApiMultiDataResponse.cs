

namespace API.DTOs.ApiResponses
{
    public class ApiMultiDataResponse<T>: ApiResponseBase
     where T : class 
    {
        public required IEnumerable<T> Data { get; set; }
        
    }
}