using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace MyProject.Gifts
{
    public class GiftSampleDataSeeder : IGiftSampleDataSeeder, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IGiftRepository _giftRepository;

        public GiftSampleDataSeeder(
            IGuidGenerator guidGenerator,
            IGiftRepository giftRepository)
        {
            _guidGenerator = guidGenerator;
            _giftRepository = giftRepository;
        }
        
        public async Task SeedAsync()
        {
            if (await _giftRepository.GetCountAsync() == 0)
            {
                await _giftRepository.InsertAsync(new Gift(_guidGenerator.Create(), "test"), true);
            }
        }
    }
}