using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public class GiftCard : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }
        
        public virtual Guid GiftCardTemplateId { get; protected set; }

        [NotNull]
        public virtual string Code { get; protected set; }
        
        [NotNull]
        public virtual string Password { get; protected set; }
        
        public virtual DateTime DueTime { get; protected set; }
        
        public virtual Guid? ConsumptionUserId { get; protected set; }
        
        public virtual DateTime? ConsumptionTime { get; protected set; }
    }
}