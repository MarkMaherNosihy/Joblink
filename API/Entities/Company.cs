using API.Entities;

namespace API.Entities;

public class Company : User
{
    public string CompanyName { get; set; }
    public short CompanySize { get; set; }
    public int Founded { get; set; }
}
