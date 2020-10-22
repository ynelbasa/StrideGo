using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrideGo.Business.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommand : IRequest<int>
    {
        public string UserId { get; set; }
        public int QuestionCategoryId { get; set; }
        public string Text { get; set; }
    }
}
