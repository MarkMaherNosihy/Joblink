namespace API;

public class UserDto
{
    public string? UserName { get; set; }
    public int Id { get; set; }

    public string? Bio { get; set; }

    public string? City { get; set; }

    public string? Country{ get; set; }
    public DateTime LastActive { get; set; } = DateTime.UtcNow;

    public DateTime AccountCreated { get; set; } = DateTime.UtcNow;

    public string? ProfilePictureURL { get; set; }
    public string? PublicId { get; set; }
}
