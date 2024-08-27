using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class UserRepository<T>: BaseRepository<T>, IUserRepository<T> where T : User
{
    public UserRepository(DataContext context) : base(context)
    {
    }

    public async Task<T> GetUserByUsernameAsync(string username)
    {
        return await _dbSet.FirstOrDefaultAsync((x)=>x.UserName == username);
    }
}
