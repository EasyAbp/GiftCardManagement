using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCards;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using MyProject.UserGifts;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace MyProject.GiftCards
{
    public class GiftCardSampleDataSeeder : IGiftCardSampleDataSeeder, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IGiftCardPasswordHashProvider _giftCardPasswordHashProvider;
        private readonly IGiftCardTemplateRepository _giftCardTemplateRepository;
        private readonly IGiftCardRepository _giftCardRepository;

        public GiftCardSampleDataSeeder(
            IGuidGenerator guidGenerator,
            IGiftCardPasswordHashProvider giftCardPasswordHashProvider,
            IGiftCardTemplateRepository giftCardTemplateRepository,
            IGiftCardRepository giftCardRepository)
        {
            _guidGenerator = guidGenerator;
            _giftCardPasswordHashProvider = giftCardPasswordHashProvider;
            _giftCardTemplateRepository = giftCardTemplateRepository;
            _giftCardRepository = giftCardRepository;
        }
        
        public async Task SeedAsync()
        {
            if (await _giftCardTemplateRepository.GetCountAsync() == 0)
            {
                var template = new GiftCardTemplate(_guidGenerator.Create(), "Gift:Test", "Gift:Test", null, false, false);

                template.SetProperty("GiftName", "test");
                
                await _giftCardTemplateRepository.InsertAsync(template, true);
                
                if (await _giftCardRepository.GetCountAsync() == 0)
                {
                    await _giftCardRepository.InsertAsync(new GiftCard(_guidGenerator.Create(), null, template.Id,
                        "100001", _giftCardPasswordHashProvider.GetPasswordHash("123456"), null), true);
                }
            }
        }
    }
}