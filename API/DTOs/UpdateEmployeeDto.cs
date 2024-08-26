using API.Entities;

namespace API.DTOs
{
    public class UpdateEmployeeDto
    {
        public string? Bio { get; set; }
        
        public string? City { get; set; }

        public string? Country{ get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? CV_URL { get; set; } = "";

         public List<Experience> Experiences { get; set; }
    }
}