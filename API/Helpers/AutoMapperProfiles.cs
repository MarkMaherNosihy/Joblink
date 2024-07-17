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
    }
}
