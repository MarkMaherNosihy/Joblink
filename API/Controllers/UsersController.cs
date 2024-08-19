using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using API.Data;
using API.Data.Repositories;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[Authorize]
public class UsersController(IUserRepository userRepo,
 IEmployeeRepository empRepo,
  IMapper mapper,
   DataContext _context,
   IPhotoService photoService
   ) : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var users = await userRepo.GetUsersAsync();
        var mappedUsers = mapper.Map<IEnumerable<UserDto>>(users);
        return Ok(mappedUsers);
    }
    [HttpGet("{username}")]
    public async Task<ActionResult<User>> GetUser(string username)
    {
        var user = await userRepo.GetUserByUserNameAsync(username);

        if (user == null) return NotFound();

        return Ok(user);
    }
    [HttpGet("employees")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
    {
        var users = await empRepo.GetEmployeesAsync();

        var mappedUsers = mapper.Map<IEnumerable<EmployeeDto>>(users);

        return Ok(mappedUsers);
    }
    [HttpGet("employees/{id:int}")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeeById(int id)
    {
        var user = await empRepo.GetEmployeeById(id);
        if (user == null) return NotFound();
        var mappedUser = mapper.Map<EmployeeDto>(user);
        return Ok(mappedUser);
    }

    [HttpGet("employees/{username}")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeeByUsername(string username)
    {
        var user = await empRepo.GetEmployeeByUsername(username);
        if (user == null) return NotFound();
        var mappedUser = mapper.Map<EmployeeDto>(user);
        return Ok(mappedUser);
    }

    [HttpPut("employees/{username}/experience")]
    public async Task<ActionResult> UpdateExperience(ExperienceDto experienceDto)
    {
        var employee = await empRepo.GetEmployeeByUsername(User.GetUsername());
        if (employee == null) return BadRequest("Could not find employee");

        // Find the existing experience entry
        var targetExperience = employee.Experiences.FirstOrDefault(x => x.Id == experienceDto.Id);
        if (targetExperience == null) return NotFound("Experience not found");

        // Map the DTO to the existing experience entity
        mapper.Map(experienceDto, targetExperience);

        // Save changes
        _context.Attach(targetExperience).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return Ok(experienceDto);
    }

    [HttpPut("update-photo")]
    public async Task<ActionResult<string>> UpdatePhoto(IFormFile file)
    {

        var user = await userRepo.GetUserByUserNameAsync(User.GetUsername());
        if(user == null){
            return BadRequest("Cannot update user");
        }
        var result = await photoService.AddPhotoAsync(file);

        if(result.Error != null) return BadRequest(result.Error.Message);
        if(user.PublicId != null) {
            var res = await photoService.DeletePhotoAsync(user.PublicId);
            if(res.Error != null) return BadRequest(res.Error.Message);
        }
        user.ProfilePictureURL = result.SecureUrl.AbsoluteUri;
        user.PublicId = result.PublicId;
        var photo = new PhotoDto{
            url = result.SecureUrl.AbsoluteUri,
        };
        if(await userRepo.SaveAllAsync())  return Ok(photo);

        return BadRequest("Could not upload the photo");
    }

}
