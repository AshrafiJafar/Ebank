using System;

namespace Framework.Core.Persistence
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
        new void Dispose();
    }
}