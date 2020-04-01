using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.GiftCardManagement.EntityFrameworkCore
{
    public class GiftCardManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public GiftCardManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}