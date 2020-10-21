using StrideGo.Business.Questions.Queries.GetQuestionDetail;
using System.Collections.Generic;

namespace StrideGo.Business.Questions.Queries.GetQuestionList
{
    public class QuestionListViewModel
    {
        public IList<QuestionViewModel> Questions { get; set; }
    }
}
