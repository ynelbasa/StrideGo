using MediatR;
using StrideGo.Business.Common.Exceptions;
using StrideGo.Business.Common.Interfaces;
using StrideGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StrideGo.Business.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand>
    {
        private readonly IDatabaseContext _context;
        public DeleteQuestionCommandHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Questions.FindAsync(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(Question), request.Id);
            }

            entity.UpdatedAt = DateTime.UtcNow;
            entity.IsActive = false;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
