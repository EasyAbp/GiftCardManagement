using System;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCards;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard
{
    public class ConsumeModel : GiftCardManagementPageModel
    {
        [BindProperty]
        public ConsumeGiftCardViewModel ConsumeGiftCard { get; set; }

        private readonly IGiftCardAppService _giftCardAppService;

        public ConsumeModel(IGiftCardAppService giftCardAppService)
        {
            _giftCardAppService = giftCardAppService;
        }
    }
}
