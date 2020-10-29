using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StrideGo.Business.Common.Interfaces;
using StrideGo.Business.Questions.Queries.GetQuestionDetail;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StrideGo.Business.Questions.Queries.GetQuestionList
{
    public class GetQuestionListQuery : IRequest<QuestionListViewModel>
    {
        public class Handler : IRequestHandler<GetQuestionListQuery, QuestionListViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IDatabaseContext _context;
            public Handler(IMapper mapper, IDatabaseContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<QuestionListViewModel> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
            {
                var questionList = await _context.Questions
                    .Where(q => q.IsActive)
                    .OrderByDescending(q => q.UpdatedAt)
                    .ThenByDescending(q=> q.CreatedAt)
                    .ProjectTo<QuestionViewModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                var viewModel = new QuestionListViewModel
                {
                    Questions = questionList
                };

                return viewModel;
            }
        }
    }
}
