namespace RuichenShuxin.AbpPro;

public class AbpProApplicationAutoMapperProfile : Profile
{
    public AbpProApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();

        // abp拓展的字段或者额外属性都会存储在ExtraProperties属性中，需要手动映射
        CreateMap<Tenant, TenantDto>().MapExtraProperties();

        CreateMap<TenantConnectionString, TenantConnectionStringDto>();

        CreateMap<OrganizationUnit, OrganizationUnitDto>().MapExtraProperties();
    }
}
