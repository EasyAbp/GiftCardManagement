using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.UserGifts;
using MyProject.UserGifts.Dtos;

namespace MyProject.Web.Pages.UserGifts.UserGift
{
    public class CreateModalModel : MyProjectPageModel
    {
        [BindProperty]
        public CreateUpdateUserGiftDto UserGift { get; set; }

        private readonly IUserGiftAppService _service;

        public CreateModalModel(IUserGiftAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(UserGift);
            return NoContent();
        }
    }
}