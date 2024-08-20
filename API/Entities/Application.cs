using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class Application
{
    [Key]
    public int JobId { get; set; }
    [Key]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public Job Job { get; set; }
    public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;


}
