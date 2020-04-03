using System.Threading.Tasks;
using MyProject.GiftCards;
using MyProject.Gifts;
using MyProject.UserGifts;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace MyProject
{
    public class MyProjectDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGiftSampleDataSeeder _giftSampleDataSeeder;
        private readonly IGiftCardSampleDataSeeder _giftCardSampleDataSeeder;

        public MyProjectDataSeedContributor(
            IGiftSampleDataSeeder giftSampleDataSeeder,
            IGiftCardSampleDataSeeder giftCardSampleDataSeeder)
        {
            _giftSampleDataSeeder = giftSampleDataSeeder;
            _giftCardSampleDataSeeder = giftCardSampleDataSeeder;
        }
        
        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            await _giftSampleDataSeeder.SeedAsync();

            await _giftCardSampleDataSeeder.SeedAsync();
        }
    }
}