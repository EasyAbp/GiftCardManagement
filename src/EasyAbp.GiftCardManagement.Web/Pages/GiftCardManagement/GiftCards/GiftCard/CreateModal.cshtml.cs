using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.GiftCardManagement.GiftCards;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCards.GiftCard
{
    public class CreateModalModel : GiftCardManagementPageModel
    {
        [BindProperty]
        public CreateUpdateGiftCardDto GiftCard { get; set; }

        private readonly IGiftCardAppService _service;

        public CreateModalModel(IGiftCardAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(GiftCard);
            return NoContent();
        }
    }
}