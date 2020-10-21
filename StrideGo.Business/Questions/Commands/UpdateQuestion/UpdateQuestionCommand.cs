using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrideGo.Business.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommand : IRequest
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
