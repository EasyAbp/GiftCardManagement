using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Gifts;
using MyProject.Gifts.Dtos;

namespace MyProject.Web.Pages.Gifts.Gift
{
    public class CreateModalModel : MyProjectPageModel
    {
        [BindProperty]
        public CreateUpdateGiftDto Gift { get; set; }

        private readonly IGiftAppService _service;

        public CreateModalModel(IGiftAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(Gift);
            return NoContent();
        }
    }
}