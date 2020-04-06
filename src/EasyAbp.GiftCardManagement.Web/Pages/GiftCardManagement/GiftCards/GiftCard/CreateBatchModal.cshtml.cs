using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCards;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard
{
    public class CreateBatchModalModel : GiftCardManagementPageModel
    {
        [BindProperty]
        public CreateBatchGiftCardViewModel CreateBatchModel { get; set; }

        private readonly IGiftCardAppService _service;

        public CreateBatchModalModel(IGiftCardAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync(Guid giftCardTemplateId)
        {
            CreateBatchModel = new CreateBatchGiftCardViewModel
            {
                GiftCardTemplateId = giftCardTemplateId
            };
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dtos = CreateBatchModel.CodesPasswords
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries))
                .Select(s => new CreateGiftCardDto
                {
                    Code = s[0],
                    Password = s[1],
                    Expiration = CreateBatchModel.Expiration,
                    GiftCardTemplateId = CreateBatchModel.GiftCardTemplateId
                }).ToList();
            
            await _service.CreateBatchAsync(dtos);
            
            return NoContent();
        }
    }
}