namespace RuichenShuxin.AbpPro.EntityFrameworkCore;

public interface IAbpProDbContext : IEfCoreDbContext
{
    DbSet<Book> Books { get; }

}
