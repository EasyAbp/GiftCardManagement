using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MyProject.UserGifts
{
    public class UserGift : FullAuditedAggregateRoot<Guid>
    {
        public virtual Guid UserId { get; protected set; }
        
        public virtual Guid GiftId { get; protected set; }

        protected UserGift()
        {
        }

        public UserGift(
            Guid id,
            Guid userId,
            Guid giftId
        ) : base(id)
        {
            UserId = userId;
            GiftId = giftId;
        }
    }
}
