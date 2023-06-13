using Lunch.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lunch.Context
{
    public class LunchContext : DbContext
    {
        public LunchContext(DbContextOptions<LunchContext> options)
            : base(options)
        {}

        public DbSet<User> User { get; set; }
    }
}