using System;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard
{
    public class IndexModel : GiftCardManagementPageModel
    {
        private readonly IGiftCardTemplateAppService _giftCardTemplateAppService;

        public GiftCardTemplateDto Template { get; set; }

        public IndexModel(IGiftCardTemplateAppService giftCardTemplateAppService)
        {
            _giftCardTemplateAppService = giftCardTemplateAppService;
        }
        
        public virtual async Task OnGetAsync(Guid templateId)
        {
            Template = await _giftCardTemplateAppService.GetAsync(templateId);
        }
    }
}
