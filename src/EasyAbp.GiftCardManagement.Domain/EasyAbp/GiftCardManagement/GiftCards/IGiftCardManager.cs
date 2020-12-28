using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public interface IGiftCardManager
    {
        Task<GiftCard> GetUsableAsync(string code, string password);
        
        Task ConsumeAsync(GiftCard giftCard, Guid? userId, ExtraPropertyDictionary extraProperties = null);
    }
}