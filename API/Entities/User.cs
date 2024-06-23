
namespace API.Entities;

public class User
{
    public string UserName { get; set; }
    public int id { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt {get; set; }
}
