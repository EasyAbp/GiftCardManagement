using EasyAbp.GiftCardManagement.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.GiftCardManagement
{
    public abstract class GiftCardManagementAppService : ApplicationService
    {
        protected GiftCardManagementAppService()
        {
            LocalizationResource = typeof(GiftCardManagementResource);
            ObjectMapperContext = typeof(GiftCardManagementApplicationModule);
        }
    }
}
