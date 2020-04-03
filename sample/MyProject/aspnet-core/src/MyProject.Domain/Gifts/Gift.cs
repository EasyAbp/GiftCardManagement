using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyProject.Gifts
{
    public class Gift : FullAuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }

        protected Gift()
        {
        }

        public Gift(
            Guid id,
            string name
        ) : base(id)
        {
            Name = name;
        }
    }
}
