using API.Entities;

namespace API.Interfaces;

public interface IUserRepository<T> : IBaseRepository<T> where T : User
{  
   public Task<T> GetUserByUsernameAsync(string username);
}
