using Framework.Core.Domain;
using System;

namespace Framework.Domain
{
    public abstract class EntityBase<TEntity> : IEntityBase where TEntity : class
    {

        public EntityBase()
        {
        }

        public long Id { get; set; }

        
    }
}
