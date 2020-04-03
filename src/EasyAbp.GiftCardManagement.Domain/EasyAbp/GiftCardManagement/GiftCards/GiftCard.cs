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
        
        public virtual DateTime? Expiration { get; protected set; }
        
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
            DateTime? expiration
        ) : base(id)
        {
            TenantId = tenantId;
            GiftCardTemplateId = giftCardTemplateId;
            Code = code;
            PasswordHash = passwordHash;
            Expiration = expiration;
        }

        public void Consume(IClock clock, Guid? userId, Dictionary<string, object> extraProperties = null)
        {
            CheckUsable(clock);
            
            ConsumptionTime = clock.Now;
            ConsumptionUserId = userId;
            
            ExtraProperties = new Dictionary<string, object>();

            if (extraProperties.IsNullOrEmpty())
            {
                return;
            }
            
            foreach (var extraProperty in extraProperties)
            {
                this.SetProperty(extraProperty.Key, extraProperty.Value);
            }
        }

        public void CheckUsable(IClock clock)
        {
            if (ConsumptionTime.HasValue)
            {
                throw new GiftCardAlreadyConsumedException(Code);
            }
            
            if (Expiration.HasValue && Expiration.Value < clock.Now)
            {
                throw new GiftCardOverdueException(Code);
            }
        }
    }
}
