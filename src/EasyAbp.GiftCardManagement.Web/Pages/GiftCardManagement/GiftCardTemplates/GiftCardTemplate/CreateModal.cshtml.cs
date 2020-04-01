using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardTemplates.GiftCardTemplate
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