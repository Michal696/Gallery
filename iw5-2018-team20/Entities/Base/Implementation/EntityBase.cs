using System;
using iw5_2018_team20.Entities.Base.Interface;

namespace iw5_2018_team20.Entities.Base.Implementation
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
