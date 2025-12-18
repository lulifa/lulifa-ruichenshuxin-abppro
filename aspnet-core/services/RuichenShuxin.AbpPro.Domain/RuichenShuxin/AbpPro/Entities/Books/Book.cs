using RuichenShuxin.AbpPro.DataProtection;

namespace RuichenShuxin.AbpPro;

public class Book : AuditedAggregateRoot<Guid>, IDataProtected
{
    public string Name { get; set; }

    public BookType Type { get; set; }

    public DateTime PublishDate { get; set; }

    public float Price { get; set; }
}