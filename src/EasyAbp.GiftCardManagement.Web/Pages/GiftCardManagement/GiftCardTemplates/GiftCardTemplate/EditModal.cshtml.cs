using System;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCardTemplates.GiftCardTemplate.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCardTemplates.GiftCardTemplate
{
    public class EditModalModel : GiftCardManagementPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateGiftCardTemplateViewModel GiftCardTemplate { get; set; }

        private readonly IGiftCardTemplateAppService _service;

        public EditModalModel(IGiftCardTemplateAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            GiftCardTemplate = ObjectMapper.Map<GiftCardTemplateDto, CreateUpdateGiftCardTemplateViewModel>(dto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id,
                ObjectMapper.Map<CreateUpdateGiftCardTemplateViewModel, CreateUpdateGiftCardTemplateDto>(
                    GiftCardTemplate));
            
            return NoContent();
        }
    }
}