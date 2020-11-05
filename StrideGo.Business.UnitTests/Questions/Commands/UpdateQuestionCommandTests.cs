using StrideGo.Business.Common.Exceptions;
using StrideGo.Business.Questions.Commands.UpdateQuestion;
using StrideGo.Business.UnitTests.Common;
using StrideGo.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StrideGo.Business.UnitTests.Questions.Commands
{
    public class UpdateQuestionCommandTests : IClassFixture<DatabaseContextFixture>
    {
        private readonly DatabaseContext _context;
        private readonly UpdateQuestionCommandHandler _sut;

        public UpdateQuestionCommandTests(DatabaseContextFixture fixture)
        {
            _context = fixture.Context;
            _sut = new UpdateQuestionCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldUpdateQuestion()
        {
            // Arrange
            var command = new UpdateQuestionCommand { Id = 1, Text = "Question Text Updated" };

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var result = await _context.Questions.FindAsync(command.Id);

            // Assert
            Assert.Equal(command.Text, result.Text);
            Assert.True(DateTime.Compare(new DateTime(2020, 1, 1), result.UpdatedAt.Value) < 0);
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ShouldThrowEntityNotFoundException()
        {
            // Arrange
            var command = new UpdateQuestionCommand { Id = 100 };

            // Act, Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _sut.Handle(command, CancellationToken.None));
        }
    }
}
