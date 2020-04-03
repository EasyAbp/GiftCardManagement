using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Gifts;
using MyProject.Gifts.Dtos;

namespace MyProject.Web.Pages.Gifts.Gift
{
    public class EditModalModel : MyProjectPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateGiftDto Gift { get; set; }

        private readonly IGiftAppService _service;

        public EditModalModel(IGiftAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            Gift = ObjectMapper.Map<GiftDto, CreateUpdateGiftDto>(dto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, Gift);
            return NoContent();
        }
    }
}