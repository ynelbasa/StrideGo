using AutoMapper;
using StrideGo.Business.Common.Mappings;
using StrideGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrideGo.Business.Answers.Queries.GetAnswerDetail
{
    public class AnswerViewModel : IMapFrom<Answer>
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Answer, AnswerViewModel>();
        }
    }
}
