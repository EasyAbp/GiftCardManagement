using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCardTemplates.GiftCardTemplate.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCardTemplates.GiftCardTemplate
{
    public class CreateModalModel : GiftCardManagementPageModel
    {
        [BindProperty]
        public CreateUpdateGiftCardTemplateViewModel GiftCardTemplate { get; set; }

        private readonly IGiftCardTemplateAppService _service;

        public CreateModalModel(IGiftCardTemplateAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(
                ObjectMapper.Map<CreateUpdateGiftCardTemplateViewModel, CreateUpdateGiftCardTemplateDto>(
                    GiftCardTemplate));
            
            return NoContent();
        }
    }
}