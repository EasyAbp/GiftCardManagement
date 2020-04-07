using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard.ViewModels
{
    public class CreateBatchGiftCardViewModel
    {
        [HiddenInput]
        public Guid GiftCardTemplateId { get; set; }

        [Required]
        [TextArea(Rows = 10)]
        [Placeholder("GiftCardCodesPasswordsPlaceholder")]
        [DisplayName("GiftCardCodesPasswords")]
        public string CodesPasswords { get; set; }

        [DisplayName("GiftCardExpiration")]
        public DateTime? Expiration { get; set; }
    }
}