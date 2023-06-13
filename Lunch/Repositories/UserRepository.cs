using Lunch.Context;
using Lunch.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lunch.Repositories
{
    public class UserRepository
    {
        private readonly LunchContext _context;

        public UserRepository(LunchContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> CreateUser(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task UpdateUser(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}