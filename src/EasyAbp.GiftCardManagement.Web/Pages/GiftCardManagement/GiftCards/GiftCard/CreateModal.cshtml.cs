using System;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCards;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard
{
    public class CreateModalModel : GiftCardManagementPageModel
    {
        [BindProperty]
        public CreateGiftCardViewModel GiftCard { get; set; }

        private readonly IGiftCardAppService _service;

        public CreateModalModel(IGiftCardAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync(Guid giftCardTemplateId)
        {
            GiftCard = new CreateGiftCardViewModel
            {
                GiftCardTemplateId = giftCardTemplateId
            };
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(
                ObjectMapper.Map<CreateGiftCardViewModel, CreateGiftCardDto>(GiftCard));
            
            return NoContent();
        }
    }
}