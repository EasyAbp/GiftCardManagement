using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyAbp.GiftCardManagement.EntityFrameworkCore
{
    public class GiftCardManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<GiftCardManagementHttpApiHostMigrationsDbContext>
    {
        public GiftCardManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<GiftCardManagementHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("GiftCardManagement"));

            return new GiftCardManagementHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
