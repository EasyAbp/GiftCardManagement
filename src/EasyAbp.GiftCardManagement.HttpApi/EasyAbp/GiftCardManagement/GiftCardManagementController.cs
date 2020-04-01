using EasyAbp.GiftCardManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.GiftCardManagement
{
    public abstract class GiftCardManagementController : AbpController
    {
        protected GiftCardManagementController()
        {
            LocalizationResource = typeof(GiftCardManagementResource);
        }
    }
}
