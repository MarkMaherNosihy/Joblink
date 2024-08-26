using API.Data;
using API.Data.Repositories;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API;

public class EmployeeRepository: UserRepository<Employee> , IEmployeeRepository
{
  public EmployeeRepository(DataContext context) : base(context)
  {
  }

  public override async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Users.OfType<Employee>().Include(x=> x.Experiences).ToListAsync();
    }
}   
