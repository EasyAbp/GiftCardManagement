using System;
using System.ComponentModel;
namespace MyProject.Gifts.Dtos
{
    public class CreateUpdateGiftDto
    {
        [DisplayName("GiftName")]
        public string Name { get; set; }
    }
}