using Framework.AssemblyHelper;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ebank.Persistence
{
    public class AccountDbContext : DbContextBase
    {
        public AccountDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entityMapping = DetectEntityMapping();

            entityMapping.ForEach(a => { modelBuilder.ApplyConfiguration(a); });
            entityMapping.ForEach(a => { modelBuilder.ApplyConfiguration(a); });

        }


        protected List<dynamic> DetectEntityMapping()
        {
            var assemblyHelper = new AssemblyHelper("Ebank");
            return assemblyHelper.GetTypes(typeof(EntityMappingBase<>))
                .Select(Activator.CreateInstance)
                .Cast<dynamic>()
                .ToList();
        }

    }
}