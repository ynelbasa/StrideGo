using MediatR;
using StrideGo.Business.Common.Interfaces;
using StrideGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StrideGo.Business.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, int>
    {
        private readonly IDatabaseContext _context;
        public CreateQuestionCommandHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            // TODO: Setup Identity and get the authenticated user
            var userId = "A7F7F628-B1BE-4884-AFBB-537B75F17CAB";

            var entity = new Question
            {
                UserId = userId,
                QuestionCategoryId = request.QuestionCategoryId,
                Text = request.Text,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.Questions.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
