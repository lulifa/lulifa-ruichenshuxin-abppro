namespace RuichenShuxin.AbpPro;

public class AbpProApplicationAutoMapperProfile : Profile
{
    public AbpProApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
    }
}
