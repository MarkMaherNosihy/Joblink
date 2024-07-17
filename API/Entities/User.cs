
namespace API.Entities;

public class User
{
    public string UserName { get; set; }
    public int id { get; set; }

    public byte[] PasswordHash { get; set; } = [];

    public byte[] PasswordSalt {get; set; } = [];

    public string? Bio { get; set; }

    public required string City { get; set; }

    public required string Country{ get; set; }
    public DateTime LastActive { get; set; } = DateTime.UtcNow;

    public DateTime AccountCreated { get; set; } = DateTime.UtcNow;

    public string ProfilePictureURL { get; set; }
}
