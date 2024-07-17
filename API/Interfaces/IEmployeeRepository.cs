using API.Entities;

namespace API.Interfaces;

public interface IEmployeeRepository
{
        Task<IEnumerable<Employee>> GetEmployeesAsync();
}
