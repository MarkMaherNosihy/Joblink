﻿using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API;

public class AutoMapperProfiles : Profile
{   
    public AutoMapperProfiles()
    {
        CreateMap<User, UserDto>();

        CreateMap<Employee, EmployeeDto>()
        .IncludeBase<User, UserDto>();
        
        CreateMap<Experience, ExperienceDto>();
        CreateMap<ExperienceDto, Experience>();
        CreateMap<RegisterDto, User>();
        CreateMap<RegisterDto, Employee>();
        CreateMap<string, DateOnly>().ConvertUsing(s=> DateOnly.Parse(s));


    }
}
