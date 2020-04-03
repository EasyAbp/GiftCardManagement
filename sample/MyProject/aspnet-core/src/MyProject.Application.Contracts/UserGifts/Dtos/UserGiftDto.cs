using System;
using Volo.Abp.Application.Dtos;

namespace MyProject.UserGifts.Dtos
{
    public class UserGiftDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public Guid GiftId { get; set; }
    }
}