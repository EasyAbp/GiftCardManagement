using System;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCards;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard
{
    public class EditModalModel : GiftCardManagementPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public UpdateGiftCardDto GiftCard { get; set; }

        private readonly IGiftCardAppService _service;

        public EditModalModel(IGiftCardAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            GiftCard = ObjectMapper.Map<GiftCardDto, UpdateGiftCardDto>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, GiftCard);
            
            return NoContent();
        }
    }
}