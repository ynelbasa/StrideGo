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
            var entity = new Question
            {
                UserId = request.UserId,
                QuestionCategoryId = request.QuestionCategoryId,
                Text = request.Text,
                IsActive = true
            };

            _context.Questions.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
