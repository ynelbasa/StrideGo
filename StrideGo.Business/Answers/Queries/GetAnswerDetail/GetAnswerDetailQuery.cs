using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StrideGo.Business.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StrideGo.Business.Answers.Queries.GetAnswerDetail
{
    public class GetAnswerDetailQuery : IRequest<AnswerViewModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetAnswerDetailQuery, AnswerViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDatabaseContext _context;
            public Handler(IMapper mapper, IDatabaseContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<AnswerViewModel> Handle(GetAnswerDetailQuery request, CancellationToken cancellationToken)
            {
                var answer = await _context.Answers
                    .ProjectTo<AnswerViewModel>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(q => q.Id == request.Id);

                return answer;
            }
        }
    }
}
