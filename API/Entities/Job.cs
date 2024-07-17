﻿namespace API.Entities;

public class Job
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string  Description { get; set; }

    public required string Location { get; set; }

    public required int OpenPositions { get; set; }

}
