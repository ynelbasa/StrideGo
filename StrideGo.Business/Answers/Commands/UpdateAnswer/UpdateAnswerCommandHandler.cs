using MediatR;
using StrideGo.Business.Common.Exceptions;
using StrideGo.Business.Common.Interfaces;
using StrideGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StrideGo.Business.Answers.Commands.UpdateAnswer
{
    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand>
    {
        private readonly IDatabaseContext _context;
        public UpdateAnswerCommandHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Answers.FindAsync(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(Answer), request.Id);
            }

            entity.Text = request.Text;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
