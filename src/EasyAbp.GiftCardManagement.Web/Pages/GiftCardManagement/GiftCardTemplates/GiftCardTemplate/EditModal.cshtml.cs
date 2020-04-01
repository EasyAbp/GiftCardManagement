using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardTemplates.GiftCardTemplate
{
    public class EditModalModel : GiftCardManagementPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateGiftCardTemplateDto GiftCardTemplate { get; set; }

        private readonly IGiftCardTemplateAppService _service;

        public EditModalModel(IGiftCardTemplateAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            GiftCardTemplate = ObjectMapper.Map<GiftCardTemplateDto, CreateUpdateGiftCardTemplateDto>(dto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, GiftCardTemplate);
            return NoContent();
        }
    }
}