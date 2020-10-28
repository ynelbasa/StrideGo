using AutoMapper;
using StrideGo.Business.Common.Mappings;
using StrideGo.Domain.Entities;

namespace StrideGo.Business.Questions.Queries.GetQuestionDetail
{
    public class QuestionViewModel : IMapFrom<Question>
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string AskedBy { get; set; }
        public int AnswerCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionViewModel>()
                .ForMember(q => q.AskedBy, opt => opt.MapFrom(u => u.User != null ? $"{u.User.UserName}" : string.Empty))
                .ForMember(q => q.AnswerCount, opt => opt.MapFrom(u => u.Answers.Count));
        }
    }
}
