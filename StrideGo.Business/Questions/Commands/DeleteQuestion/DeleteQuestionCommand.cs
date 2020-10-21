using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrideGo.Business.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
