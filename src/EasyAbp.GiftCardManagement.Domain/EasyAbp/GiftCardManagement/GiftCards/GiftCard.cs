using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Timing;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public class GiftCard : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }
        
        public virtual Guid GiftCardTemplateId { get; protected set; }

        [NotNull]
        public virtual string Code { get; protected set; }
        
        [NotNull]
        public virtual string PasswordHash { get; protected set; }
        
        [CanBeNull]
        public virtual string ExtraInformation { get; protected set; }
        
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
            [NotNull] string code,
            [NotNull] string passwordHash,
            [CanBeNull] string extraInformation,
            DateTime dueTime,
            Guid? consumptionUserId,
            DateTime? consumptionTime
        ) : base(id)
        {
            TenantId = tenantId;
            GiftCardTemplateId = giftCardTemplateId;
            Code = code;
            PasswordHash = passwordHash;
            ExtraInformation = extraInformation;
            DueTime = dueTime;
            ConsumptionUserId = consumptionUserId;
            ConsumptionTime = consumptionTime;
        }

        public void Consume(IClock clock, Guid? userId, string extraInformation = null)
        {
            CheckUsable(clock);
            
            ConsumptionTime = clock.Now;
            ConsumptionUserId = userId;
            ExtraInformation = extraInformation;
        }

        public void CheckUsable(IClock clock)
        {
            if (ConsumptionTime.HasValue)
            {
                throw new GiftCardAlreadyConsumedException(Code);
            }
            
            if (DueTime < clock.Now)
            {
                throw new GiftCardOverdueException(Code);
            }
        }
    }
}
