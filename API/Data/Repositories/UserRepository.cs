using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await context.Users.FindAsync(userId);
    }

    public async Task<User> GetUserByUserNameAsync(string userName)
    {
        return await context.Users.SingleOrDefaultAsync(user => user.UserName == userName);
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await context.Users.Include(x=> (x as Employee).Experiences).ToListAsync();

    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void Update(User user)
    {
        context.Entry(user).State = EntityState.Modified;
    }
}
