using API.Extensions;

namespace API.Entities;

public class Employee : User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public required DateOnly DateOfBirth { get; set; }
    public required string Gender { get; set; }
    public string CV_URL { get; set; } = "";

    public List<Experience> Experiences { get; set; }
        public int GetAge(){
        return DateOfBirth.CalculateAge();
    }
}
