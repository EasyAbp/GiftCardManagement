using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace MyProject.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(MyProjectHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MyProjectConsoleApiClientModule : AbpModule
    {
        
    }
}
