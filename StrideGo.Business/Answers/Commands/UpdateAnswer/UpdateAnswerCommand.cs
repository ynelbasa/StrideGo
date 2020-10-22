using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrideGo.Business.Answers.Commands.UpdateAnswer
{
    public class UpdateAnswerCommand : IRequest
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
