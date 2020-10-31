using MediatR;
using StrideGo.Business.Common.Interfaces;
using StrideGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StrideGo.Business.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, int>
    {
        private readonly IDatabaseContext _context;
        public CreateAnswerCommandHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Answer
            {
                QuestionId = request.QuestionId,
                UserId = request.UserId,
                Text = request.Text,
                CreatedAt = DateTime.UtcNow,
                IsActive = true                
            };

            _context.Answers.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
