using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.GiftCardManagement.GiftCards;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCards.GiftCard
{
    public class EditModalModel : GiftCardManagementPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateGiftCardDto GiftCard { get; set; }

        private readonly IGiftCardAppService _service;

        public EditModalModel(IGiftCardAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            GiftCard = ObjectMapper.Map<GiftCardDto, CreateUpdateGiftCardDto>(dto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, GiftCard);
            return NoContent();
        }
    }
}