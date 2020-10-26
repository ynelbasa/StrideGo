using Microsoft.EntityFrameworkCore;
using StrideGo.Business.Common.Interfaces;
using StrideGo.Domain.Entities;

namespace StrideGo.Storage
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<QuestionVote> QuestionVotes { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionCategory>().HasData(
                new QuestionCategory { Id = 1, Name = "Training" },
                new QuestionCategory { Id = 2, Name = "Injury & Recovery" },
                new QuestionCategory { Id = 3, Name = "Running Gears" },
                new QuestionCategory { Id = 4, Name = "Nutrition" });
        }
    }
}
