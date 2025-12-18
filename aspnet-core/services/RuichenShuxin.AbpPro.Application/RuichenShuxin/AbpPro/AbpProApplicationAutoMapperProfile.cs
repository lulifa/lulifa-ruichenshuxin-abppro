namespace RuichenShuxin.AbpPro;

public class AbpProApplicationAutoMapperProfile : Profile
{
    public AbpProApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>()
            .Ignore(dto => dto.AuthorName);
        CreateMap<BookImportDto, Book>()
            .IgnoreAuditedObjectProperties()
            .Ignore(dto => dto.Id)
            .Ignore(dto => dto.ExtraProperties)
            .Ignore(dto => dto.ConcurrencyStamp);
        CreateMap<UpdateBookDto, Book>()
            .IgnoreAuditedObjectProperties()
            .Ignore(dto => dto.Id)
            .Ignore(dto => dto.ExtraProperties)
            .Ignore(dto => dto.ConcurrencyStamp);
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();
    }
}
