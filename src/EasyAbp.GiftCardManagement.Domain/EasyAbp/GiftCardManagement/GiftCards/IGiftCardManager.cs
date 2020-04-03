using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public interface IGiftCardManager
    {
        Task<GiftCard> GetUsableAsync(string code, string password);
        
        Task ConsumeAsync(GiftCard giftCard, Guid? userId, Dictionary<string, object> extraProperties = null);
    }
}