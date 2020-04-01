using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.GiftCardManagement.GiftCardTemplates
{
    public interface IGiftCardTemplateRepository : IRepository<GiftCardTemplate, Guid>
    {
    }
}