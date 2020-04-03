using System;
using Volo.Abp.Domain.Repositories;

namespace MyProject.UserGifts
{
    public interface IUserGiftRepository : IRepository<UserGift, Guid>
    {
    }
}