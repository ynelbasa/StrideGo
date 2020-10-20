using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StrideGo.Domain.Entities
{
    [Table("User", Schema = "StrideGo")]
    public class User
    {
        public int Id { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
    }
}
