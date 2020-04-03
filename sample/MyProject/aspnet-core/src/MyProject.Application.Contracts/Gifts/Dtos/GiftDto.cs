using System;
using Volo.Abp.Application.Dtos;

namespace MyProject.Gifts.Dtos
{
    public class GiftDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}