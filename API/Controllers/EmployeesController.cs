
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
        public async Task<ActionResult<ApiMultiDataResponse<EmployeeDto>>> GetAllEmployees()
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
        [HttpGet("{username}")]

        public async Task<ActionResult<ApiSingleDataResponse<EmployeeDto>>> GetEmployeeByUserName(string username){
            
            var employee = await employeeRepository.GetUserByUsernameAsync(username);
            if(employee == null){
                return NotFound("Employee not found!");
            }
            var mappedEmployee = mapper.Map<EmployeeDto>(employee);

            return Ok(
                new ApiSingleDataResponse<EmployeeDto>{
                    Status = "Success",
                    Message = "Employees retrieved successfully",
                    Data = mappedEmployee,
                }
            );
        }
    }
}