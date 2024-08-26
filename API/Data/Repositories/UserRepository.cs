using API.Entities;
using API.Interfaces;

namespace API.Data.Repositories;

public class UserRepository<T>: BaseRepository<T>, IUserRepository<T> where T : User
{
    public UserRepository(DataContext context) : base(context)
    {
    }

    public Task<T> GetUserByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }
}
