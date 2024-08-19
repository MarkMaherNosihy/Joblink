using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    public  string Username { get; set; }
    [Required]
    [StringLength(16, MinimumLength = 8)]
    public  string Password { get; set; } 
    
    [Required]

    public string Country { get; set; }

    [Required]

    public string City { get; set; }

    [Required]

    public string Gender { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string DateOfBirth { get; set; }

}
