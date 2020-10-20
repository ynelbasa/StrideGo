using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StrideGo.Domain.Entities
{
    [Table("QuestionCategory", Schema = "StrideGo")]
    public class QuestionCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
