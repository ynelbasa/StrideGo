using Microsoft.EntityFrameworkCore;
using StrideGo.Business.Common.Interfaces;

namespace StrideGo.Storage
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
    }
}
