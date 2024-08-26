 
namespace API.DTOs.ApiResponses
{
    public class ApiResponseBase<T> where T : class
    {
        public required string Status { get; set; }
        public string? Message { get; set; }
    }
}