using System;

namespace API.DTOs;

public class RegisterResponseDto
{
    public required string Token { get; set; }
    public required string Username { get; set; }

}
