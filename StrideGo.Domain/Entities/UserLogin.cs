using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StrideGo.Domain.Entities
{
    [Table("UserLogin", Schema = "StrideGo")]
    public class UserLogin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
