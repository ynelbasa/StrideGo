using Microsoft.EntityFrameworkCore;
using StrideGo.Business.Common.Interfaces;
using StrideGo.Domain.Entities;

namespace StrideGo.Storage
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UsersLogin { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
