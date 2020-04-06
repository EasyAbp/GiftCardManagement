using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCardTemplates.GiftCardTemplate
{
    public class CreateModalModel : GiftCardManagementPageModel
    {
        [BindProperty]
        public CreateUpdateGiftCardTemplateDto GiftCardTemplate { get; set; }

        private readonly IGiftCardTemplateAppService _service;

        public CreateModalModel(IGiftCardTemplateAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(GiftCardTemplate);
            return NoContent();
        }
    }
}