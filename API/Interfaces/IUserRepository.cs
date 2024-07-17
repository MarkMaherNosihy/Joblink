using API.Entities;

namespace API.Interfaces;

public interface IUserRepository
{  
    void Update(User user);

    Task<bool> SaveAllAsync();

    Task<IEnumerable<User>> GetUsersAsync();

    Task<User?> GetUserByIdAsync(int userId);

    Task<User?> GetUserByUserNameAsync(string userName);
}
