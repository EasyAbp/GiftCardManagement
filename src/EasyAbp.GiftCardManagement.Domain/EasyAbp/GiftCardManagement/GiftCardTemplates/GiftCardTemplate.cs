using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.GiftCardManagement.GiftCardTemplates
{
    public class GiftCardTemplate : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; protected set; }
        
        [NotNull]
        public virtual string DisplayName { get; protected set; }
        
        [CanBeNull]
        public virtual string Description { get; protected set; }
        
        public virtual bool TenantAllowed { get; protected set; }
        
        public virtual bool AnonymousConsumptionAllowed { get; protected set; }
        
        protected GiftCardTemplate()
        {
        }

        public GiftCardTemplate(
            Guid id,
            [NotNull] string name,
            [NotNull] string displayName,
            [CanBeNull] string description,
            bool tenantAllowed,
            bool anonymousConsumptionAllowed
        ) : base(id)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
            TenantAllowed = tenantAllowed;
            AnonymousConsumptionAllowed = anonymousConsumptionAllowed;
        }
    }
}
