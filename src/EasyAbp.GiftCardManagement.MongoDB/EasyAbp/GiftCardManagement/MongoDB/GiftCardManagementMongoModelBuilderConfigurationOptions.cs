using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace EasyAbp.GiftCardManagement.MongoDB
{
    public class GiftCardManagementMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public GiftCardManagementMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}