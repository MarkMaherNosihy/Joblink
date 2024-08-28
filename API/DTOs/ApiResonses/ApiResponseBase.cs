 
namespace API.DTOs.ApiResponses
{
    public class ApiResponseBase 
    {
        public required string Status { get; set; }
        public string? Message { get; set; }
    }
}