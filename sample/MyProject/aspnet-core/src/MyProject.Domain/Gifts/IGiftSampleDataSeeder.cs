using System.Threading.Tasks;
using Volo.Abp.Data;

namespace MyProject.Gifts
{
    public interface IGiftSampleDataSeeder
    {
        Task SeedAsync();
    }
}