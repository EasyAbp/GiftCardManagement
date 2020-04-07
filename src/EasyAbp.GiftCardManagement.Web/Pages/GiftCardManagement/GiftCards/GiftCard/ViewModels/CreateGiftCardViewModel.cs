using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard.ViewModels
{
    public class CreateGiftCardViewModel
    {
        [HiddenInput]
        public Guid GiftCardTemplateId { get; set; }

        [Required]
        [DisplayName("GiftCardCode")]
        public string Code { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("GiftCardPassword")]
        public string Password { get; set; }

        [DisplayName("GiftCardExpiration")]
        public DateTime? Expiration { get; set; }
    }
}