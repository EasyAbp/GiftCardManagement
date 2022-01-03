using EasyAbp.GiftCardManagement.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.GiftCardManagement
{
    [Area(GiftCardManagementRemoteServiceConsts.ModuleName)]
    public abstract class GiftCardManagementController : AbpControllerBase
    {
        protected GiftCardManagementController()
        {
            LocalizationResource = typeof(GiftCardManagementResource);
        }
    }
}
