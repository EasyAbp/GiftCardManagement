using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace EasyAbp.GiftCardManagement.EntityFrameworkCore
{
    public static class GiftCardManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureGiftCardManagement(
            this ModelBuilder builder,
            Action<GiftCardManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new GiftCardManagementModelBuilderConfigurationOptions(
                GiftCardManagementDbProperties.DbTablePrefix,
                GiftCardManagementDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureFullAuditedAggregateRoot();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */
        }
    }
}