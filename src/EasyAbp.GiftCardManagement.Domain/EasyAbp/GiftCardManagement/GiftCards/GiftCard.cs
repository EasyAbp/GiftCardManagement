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

        protected GiftCard()
        {
        }

        public GiftCard(
            Guid id,
            Guid? tenantId,
            Guid giftCardTemplateId,
            string code,
            string password,
            DateTime dueTime,
            Guid? consumptionUserId,
            DateTime? consumptionTime
        ) :base(id)
        {
            TenantId = tenantId;
            GiftCardTemplateId = giftCardTemplateId;
            Code = code;
            Password = password;
            DueTime = dueTime;
            ConsumptionUserId = consumptionUserId;
            ConsumptionTime = consumptionTime;
        }
    }
}
