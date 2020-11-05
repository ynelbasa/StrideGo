using Microsoft.EntityFrameworkCore;
using StrideGo.Domain.Entities;
using StrideGo.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrideGo.Business.UnitTests.Common
{
    public class DatabaseContextFixture : IDisposable
    {
        public readonly DatabaseContext Context;

        public DatabaseContextFixture() {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            Context = new DatabaseContext(options);
            Context.Database.EnsureCreated();

            Context.Questions.Add(new Question
            {
                Id = 1,
                UserId = Guid.NewGuid().ToString(),
                QuestionCategoryId = (int)QuestionCategoryEnum.Training,
                Text = "Question Text",
                CreatedAt = new DateTime(2020, 1, 1),
                UpdatedAt = new DateTime(2020, 1, 1),
                IsActive = true
            });

            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
