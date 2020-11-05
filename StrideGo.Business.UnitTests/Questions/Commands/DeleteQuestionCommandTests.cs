using StrideGo.Business.Common.Exceptions;
using StrideGo.Business.Questions.Commands.DeleteQuestion;
using StrideGo.Business.UnitTests.Common;
using StrideGo.Domain.Entities;
using StrideGo.Storage;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StrideGo.Business.UnitTests.Questions.Commands
{
    public class DeleteQuestionCommandTests : IClassFixture<DatabaseContextFixture>
    {
        private readonly DatabaseContext _context;
        private readonly DeleteQuestionCommandHandler _sut;

        public DeleteQuestionCommandTests(DatabaseContextFixture fixture) 
        {
            _context = fixture.Context;
            _sut = new DeleteQuestionCommandHandler(_context);
        }


        [Fact]
        public async Task Handle_GivenValidRequest_ShouldDeleteQuestion()
        {
            // Arrange
            var command = new DeleteQuestionCommand { Id = 1 };

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var result = await _context.Questions.FindAsync(command.Id);

            // Assert
            Assert.False(result.IsActive);
            Assert.True(DateTime.Compare(new DateTime(2020, 1, 1), result.UpdatedAt.Value) < 0);
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ShouldThrowEntityNotFoundException()
        {
            // Arrange
            var command = new DeleteQuestionCommand { Id = 100 };

            // Act, Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _sut.Handle(command, CancellationToken.None));
        }
    }
}
