using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

[Table("Experiences")]
public class Experience
{
    public int Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    public string CompanyName { get; set; }

    public int EmployeeId { get; set; }

    public Employee Employee { get; set; } = null!;
}
