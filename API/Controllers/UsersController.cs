using System.Reflection.Metadata.Ecma335;
using API.Data;
using API.Data.Repositories;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[Authorize]
public class UsersController (IUserRepository userRepo, IEmployeeRepository empRepo, IMapper mapper) : BaseApiController
{
    private readonly DataContext _context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers(){
        var users =  await userRepo.GetUsersAsync();
        var mappedUsers = mapper.Map<IEnumerable<UserDto>>(users);
        return Ok(mappedUsers);
    }
    [HttpGet("{username}")]
    public async Task<ActionResult<User>> GetUser(string username){
        var user = await userRepo.GetUserByUserNameAsync(username);

        if(user == null) return NotFound();

        return Ok(user);
    }
    [HttpGet("employees")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees(){
            var users = await empRepo.GetEmployeesAsync();

            var mappedUsers = mapper.Map<IEnumerable<EmployeeDto>>(users);

            return Ok(mappedUsers);
        }
        [HttpGet("employees/{id:int}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeeById(int id){
            var user = await empRepo.GetEmployeeById(id);
            if(user == null) return NotFound();
            var mappedUser = mapper.Map<EmployeeDto>(user);
            return Ok(mappedUser);
        }

        [HttpGet("employees/{username}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeeByUsername(string username){
            var user = await empRepo.GetEmployeeByUsername(username);
            if(user == null) return NotFound();
            var mappedUser = mapper.Map<EmployeeDto>(user);
            return Ok(mappedUser);
        }
}
