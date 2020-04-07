using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard.ViewModels
{
    public class ConsumeGiftCardViewModel
    {
        [Required]
        [DisplayName("GiftCardCode")]
        public string Code { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("GiftCardPassword")]
        public string Password { get; set; }
    }
}