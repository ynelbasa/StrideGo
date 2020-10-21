using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StrideGo.Business.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace StrideGo.Business.Questions.Queries.GetQuestionDetail
{
    public class GetQuestionDetailQuery : IRequest<QuestionViewModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetQuestionDetailQuery, QuestionViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDatabaseContext _context;
            public Handler(IMapper mapper, IDatabaseContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<QuestionViewModel> Handle(GetQuestionDetailQuery request, CancellationToken cancellationToken)
            {
                var question = await _context.Questions
                    .ProjectTo<QuestionViewModel>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(q => q.Id == request.Id);

                return question;
            }
        }
    }
}
