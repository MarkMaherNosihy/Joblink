namespace API;

public class EmployeeDto : UserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public string? CV_URL { get; set; }
    public List<ExperienceDto> Experiences { get; set; }

}
