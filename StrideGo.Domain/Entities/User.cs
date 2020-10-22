using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StrideGo.Domain.Entities
{
    [Table("User", Schema = "StrideGo")]
    public class User : IdentityUser
    {
    }
}
