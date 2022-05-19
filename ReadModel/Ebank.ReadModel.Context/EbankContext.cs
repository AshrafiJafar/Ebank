using Ebank.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Ebank.ReadModel.Context
{
    public class EbankContext : EbDbContext
    {
        public EbankContext(DbContextOptions options) : base(options)
        {
        }
    }
}