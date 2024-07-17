using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API;

public class EmployeeRepository(DataContext context) : IEmployeeRepository
{
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return await context.Users.OfType<Employee>().Include(x=> x.Experiences).ToListAsync();

    }
}   
