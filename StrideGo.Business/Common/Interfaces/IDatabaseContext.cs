using Microsoft.EntityFrameworkCore;
using StrideGo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StrideGo.Business.Common.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<QuestionCategory> QuestionCategories { get; set; }
        DbSet<QuestionVote> QuestionVotes { get; set; }
        DbSet<Answer> Answers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
