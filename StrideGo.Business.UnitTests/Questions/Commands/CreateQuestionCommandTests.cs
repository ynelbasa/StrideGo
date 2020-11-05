using StrideGo.Business.Questions.Commands.CreateQuestion;
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
    public class CreateQuestionCommandTests : IClassFixture<DatabaseContextFixture>
    {
        private readonly DatabaseContext _context;
        private readonly CreateQuestionCommandHandler _sut;

        public CreateQuestionCommandTests(DatabaseContextFixture fixture)
        {
            _context = fixture.Context;
            _sut = new CreateQuestionCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateQuestion() {
            // Arrange
            var command = new CreateQuestionCommand { UserId = Guid.NewGuid().ToString(), Text = "Question Text" };

            // Act
            var questionId = await _sut.Handle(command, CancellationToken.None);
            var result = await _context.Questions.FindAsync(questionId);

            // Assert
            Assert.NotNull(result);
        }
    }
} 