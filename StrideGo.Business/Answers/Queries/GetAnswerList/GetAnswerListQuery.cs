using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StrideGo.Business.Answers.Queries.GetAnswerDetail;
using StrideGo.Business.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StrideGo.Business.Answers.Queries.GetAnswerList
{
    public class GetAnswerListQuery : IRequest<AnswerListViewModel>
    {
        public int? QuestionId { get; set; }

        public class Handler : IRequestHandler<GetAnswerListQuery, AnswerListViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDatabaseContext _context;
            public Handler(IMapper mapper, IDatabaseContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<AnswerListViewModel> Handle(GetAnswerListQuery request, CancellationToken cancellationToken)
            {
                var answerList = await _context.Answers
                    .Where(a => !request.QuestionId.HasValue || a.QuestionId == request.QuestionId)
                    .OrderByDescending(a => a.CreatedAt)
                    .ThenByDescending(a => a.UpdatedAt)
                    .ProjectTo<AnswerViewModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                var viewModel = new AnswerListViewModel
                {
                    Answers = answerList
                };

                return viewModel;
            }
        }
    }
}
