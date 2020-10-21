using MediatR;
using StrideGo.Business.Common.Exceptions;
using StrideGo.Business.Common.Interfaces;
using StrideGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StrideGo.Business.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand>
    {
        private readonly IDatabaseContext _context;
        public UpdateQuestionCommandHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Questions.FindAsync(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(Question), request.Id);
            }

            entity.Text = request.Text;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
