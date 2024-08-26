
using API.DTOs.ApiResponses;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // [Authorize]
    public class EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper, IPhotoService photoService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var employees = await employeeRepository.GetAllAsync();
            var mappedEmployees = mapper.Map<IEnumerable<EmployeeDto>>(employees);
           
            return Ok(
                new ApiMultiDataResponse<EmployeeDto>{
                    Status = "Success",
                    Message = "Employees retrieved successfully",
                    Data = mappedEmployees,
                }

            );
        }
         
    }
}