 

using System.Collections.Generic;

namespace CleanArchitecture.Core.Contracts
{
   
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public List<DomainEventBase> Events = new List<DomainEventBase>();
    }
}
