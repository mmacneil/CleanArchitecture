

using System;

namespace CleanArchitecture.Core.Contracts
{
    public abstract class DomainEventBase
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
