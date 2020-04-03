using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.UserGifts;
using MyProject.UserGifts.Dtos;

namespace MyProject.Web.Pages.UserGifts.UserGift
{
    public class EditModalModel : MyProjectPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateUserGiftDto UserGift { get; set; }

        private readonly IUserGiftAppService _service;

        public EditModalModel(IUserGiftAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            UserGift = ObjectMapper.Map<UserGiftDto, CreateUpdateUserGiftDto>(dto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, UserGift);
            return NoContent();
        }
    }
}