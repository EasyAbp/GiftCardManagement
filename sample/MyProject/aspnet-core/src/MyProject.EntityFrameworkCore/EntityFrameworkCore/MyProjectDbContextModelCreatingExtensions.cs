using MyProject.UserGifts;
using MyProject.Gifts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.Users;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MyProject.EntityFrameworkCore
{
    public static class MyProjectDbContextModelCreatingExtensions
    {
        public static void ConfigureMyProject(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(MyProjectConsts.DbTablePrefix + "YourEntities", MyProjectConsts.DbSchema);

            //    //...
            //});

            builder.Entity<Gift>(b =>
            {
                b.ToTable(MyProjectConsts.DbTablePrefix + "Gifts", MyProjectConsts.DbSchema);
                b.ConfigureByConvention(); 
                /* Configure more properties here */
            });

            builder.Entity<UserGift>(b =>
            {
                b.ToTable(MyProjectConsts.DbTablePrefix + "UserGifts", MyProjectConsts.DbSchema);
                b.ConfigureByConvention(); 
                /* Configure more properties here */
            });
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser: class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}
