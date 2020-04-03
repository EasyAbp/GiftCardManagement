using System;
using System.ComponentModel;
namespace MyProject.UserGifts.Dtos
{
    public class CreateUpdateUserGiftDto
    {
        [DisplayName("UserGiftUserId")]
        public Guid UserId { get; set; }

        [DisplayName("UserGiftGiftId")]
        public Guid GiftId { get; set; }
    }
}