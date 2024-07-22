using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API;

public class EmployeeRepository(DataContext context) : IEmployeeRepository
{
    public async Task<Employee> GetEmployeeById(int id)
    {
        return await context.Users.OfType<Employee>().Where(x=> x.id == id).Include(x=>x.Experiences).SingleOrDefaultAsync();
    }

    public async Task<Employee> GetEmployeeByUsername(string username)
    {
        return await context.Users.OfType<Employee>().Where(x=> x.UserName == username).Include(x=>x.Experiences).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return await context.Users.OfType<Employee>().Include(x=> x.Experiences).ToListAsync();

    }
}   
