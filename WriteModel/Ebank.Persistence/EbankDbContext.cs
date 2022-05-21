using Ebank.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Ebank.Persistence
{
    public class EbankDbContext : EbDbContext
    {
        public EbankDbContext(DbContextOptions<EbankDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

    }
}