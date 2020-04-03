using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace MyProject.EntityFrameworkCore
{
    [DependsOn(
        typeof(MyProjectEntityFrameworkCoreModule)
        )]
    public class MyProjectEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MyProjectMigrationsDbContext>();
        }
    }
}
