using System;
using MyProject.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MyProject.UserGifts
{
    public class UserGiftRepository : EfCoreRepository<IMyProjectDbContext, UserGift, Guid>, IUserGiftRepository
    {
        public UserGiftRepository(IDbContextProvider<MyProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}