
using API.DTOs;
using API.DTOs.ApiResonses;
using API.DTOs.ApiResponses;
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
        
        [HttpGet("{username:alpha}")]
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


        [HttpPatch("{id:int}")]
        public async Task<ActionResult<ApiSingleDataResponse<EmployeeDto>>> UpdateEmployee(
            [FromBody]UpdateEmployeeDto empData,
            [FromRoute] int id
            ){
                var employee = await employeeRepository.GetByIdAsync(id);
                if(employee == null){
                    return NotFound("Employee not found!");
                }
                mapper.Map(empData, employee);
                employeeRepository.Update(employee);
                var UpdateResult = await employeeRepository.SaveAllAsync();
                if(!UpdateResult){
                    return BadRequest(
                        new ApiErrorResponse{
                            Status = "Error",
                            Message = "Failed to update employee"
                        }
                    );
                }
                var mappedEmployee = mapper.Map<EmployeeDto>(employee);
                return Ok(
                    new ApiSingleDataResponse<EmployeeDto>{
                        Status = "Success",
                        Message = "Employee updated successfully",
                        Data = mappedEmployee,
                    }
                );
            }



    }
    

       


}