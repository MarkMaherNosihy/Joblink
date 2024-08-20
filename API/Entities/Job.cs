namespace API.Entities;

public class Job
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string  Description { get; set; }

    public required string Location { get; set; }

    public required int OpenPositions { get; set; }

    public required string Type { get; set; }
    public required string Field { get; set; }

    public ICollection<Application> Applications { get; set; }


}
