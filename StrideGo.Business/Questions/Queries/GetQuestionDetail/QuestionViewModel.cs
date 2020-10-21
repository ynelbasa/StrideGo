using AutoMapper;
using StrideGo.Business.Common.Mappings;
using StrideGo.Domain.Entities;

namespace StrideGo.Business.Questions.Queries.GetQuestionDetail
{
    public class QuestionViewModel : IMapFrom<Question>
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionViewModel>();
        }
    }
}
