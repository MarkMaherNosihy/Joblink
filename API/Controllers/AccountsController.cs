using System.Security.Cryptography;
using System.Text;
using API.Controllers;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

public class AccountsController : BaseApiController
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public AccountsController(DataContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }


    [HttpPost("register")]
    public async Task<ActionResult<LoginResponseDto>> Register(RegisterDto registerDto)
    {

        if(await UserAlreadyExists(registerDto.Username)){
            return BadRequest("Username already exists.");
        }

        return Ok();
        // using var hmac = new HMACSHA512();

        // var user = new User{
        //     UserName = registerDto.Username.ToLower(),
        //     PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        //     PasswordSalt = hmac.Key
        // };

        // _context.Users.Add(user);

        // await _context.SaveChangesAsync();

        // return new UserDto{
        //     Username = user.UserName,
        //     token = _tokenService.CreateToken(user)
        // };
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginDto loginDto){

        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

        if(user == null){
            return Unauthorized("Invalid Username");
        }

        using var hmac = new HMACSHA512(user.PasswordSalt);

        var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for(int i = 0; i < hashedPassword.Length; i++){
            if(hashedPassword[i] != user.PasswordHash[i]){
                return Unauthorized("Invalid Password");
            }
        }

        return new LoginResponseDto{
            Username = user.UserName,
            token = _tokenService.CreateToken(user)
        };
    }

    public async Task<bool> UserAlreadyExists(string username){

        return await _context.Users.AnyAsync((x)=> x.UserName == username.ToLower());
    }
}
