using Microsoft.EntityFrameworkCore;
using StrideGo.Business.Common.Interfaces;
using StrideGo.Domain.Entities;

namespace StrideGo.Storage
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<QuestionVote> QuestionVotes { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
