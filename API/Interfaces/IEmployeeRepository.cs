using API.Entities;

namespace API.Interfaces;

public interface IEmployeeRepository
{
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> GetEmployeeByUsername(string username);

}
