using System.Security.Cryptography;
using System.Text;
using API.Controllers;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

public class AccountsController : BaseApiController
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    private readonly IMapper _mapper;
    public AccountsController(DataContext context, ITokenService tokenService, IMapper mapper)
    {
        _context = context;
        _tokenService = tokenService;
        _mapper = mapper;
    }


    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponseDto>> Register(RegisterDto registerDto)
    {

        if(await UserAlreadyExists(registerDto.Username)){
            return BadRequest("Username already exists.");
        }
        using var hmac = new HMACSHA512();


        var user = _mapper.Map<Employee>(registerDto);

        user.UserName = registerDto.Username.ToLower();
        user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
        user.PasswordSalt = hmac.Key;

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return new RegisterResponseDto{
            Token = _tokenService.CreateToken(user),
            Username = user.UserName
        };
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
