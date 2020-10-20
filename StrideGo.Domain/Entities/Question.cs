using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StrideGo.Domain.Entities
{
    [Table("Question", Schema = "StrideGo")]
    public class Question
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestionCategoryId { get; set; }
        public string Text { get; set; }
        public bool IsActive { get; set; }
    }
}
