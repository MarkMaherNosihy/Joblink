

namespace API.DTOs.ApiResponses
{
    public class ApiMultiDataResponse<T>: ApiResponseBase<T>
     where T : class 
    {
        public required IEnumerable<T> Data { get; set; }
        
    }
}