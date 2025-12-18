namespace RuichenShuxin.AbpPro.EntityFrameworkCore;

public static class AbpProDbContextModelCreatingExtensions
{

    public static void ConfigureAbpPro(this ModelBuilder builder)
    {
        builder.Entity<Book>(b =>
        {
            b.ToTable(AbpProDbProperties.DbTablePrefix + "Books", AbpProDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(AbpProCoreConsts.MaxLength128);
        });

        builder.ConfigureEntityAuth<Book, Guid, BookAuth>();
    }

}
