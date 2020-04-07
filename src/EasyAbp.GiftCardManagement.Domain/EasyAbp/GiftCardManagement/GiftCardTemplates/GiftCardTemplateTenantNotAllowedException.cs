using System;
using Volo.Abp;

namespace EasyAbp.GiftCardManagement.GiftCardTemplates
{
    public class GiftCardTemplateTenantNotAllowedException : BusinessException
    {
        public GiftCardTemplateTenantNotAllowedException(Guid id) : base(
            message: $"Tenants are not allowed to consume the specified gift card template: {id}")
        {

        }
    }
}