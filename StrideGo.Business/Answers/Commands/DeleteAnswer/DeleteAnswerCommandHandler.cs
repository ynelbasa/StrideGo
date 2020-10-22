using MediatR;
using StrideGo.Business.Common.Exceptions;
using StrideGo.Business.Common.Interfaces;
using StrideGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StrideGo.Business.Answers.Commands.DeleteAnswer
{
    public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommand>
    {
        private readonly IDatabaseContext _context;
        public DeleteAnswerCommandHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Answers.FindAsync(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(Answer), request.Id);
            }

            entity.IsActive = false;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
