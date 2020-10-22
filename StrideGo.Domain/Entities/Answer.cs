using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StrideGo.Domain.Entities
{
    [Table("Answer", Schema = "StrideGo")]
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public bool IsActive { get; set; }

        public Question Question { get; set; }
    }
}
