using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrideGo.Business.Answers.Commands.CreateAnswer
{
    public class CreateAnswerCommand : IRequest<int>
    {
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
    }
}
