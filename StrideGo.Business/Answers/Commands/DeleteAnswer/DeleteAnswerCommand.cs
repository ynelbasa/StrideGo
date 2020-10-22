using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrideGo.Business.Answers.Commands.DeleteAnswer
{
    public class DeleteAnswerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
