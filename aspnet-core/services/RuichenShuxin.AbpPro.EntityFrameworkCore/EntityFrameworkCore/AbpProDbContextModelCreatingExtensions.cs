namespace RuichenShuxin.AbpPro.EntityFrameworkCore;

public static class AbpProDbContextModelCreatingExtensions
{

    public static void ConfigureAbpPro(this ModelBuilder builder)
    {
        builder.Entity<Book>(b =>
        {
            b.ToTable(AbpProDbProperties.DbTablePrefix + "Books", AbpProDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(AbpProCoreConsts.MaxLength128);
        });

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(AbpProConsts.DbTablePrefix + "YourEntities", AbpProConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }

}
