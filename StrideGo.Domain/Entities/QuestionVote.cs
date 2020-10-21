using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StrideGo.Domain.Entities
{
    [Table("QuestionVote", Schema = "StrideGo")]
    public class QuestionVote
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public bool IsUpvote { get; set; }

        public Question Question { get; set; }
        public User User { get; set; }
    }
}
