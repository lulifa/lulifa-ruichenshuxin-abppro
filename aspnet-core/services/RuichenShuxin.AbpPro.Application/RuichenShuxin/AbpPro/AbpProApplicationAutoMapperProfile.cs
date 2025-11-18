namespace RuichenShuxin.AbpPro;

public class AbpProApplicationAutoMapperProfile : Profile
{
    public AbpProApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();

        // abp拓展的字段或者额外属性都会存储在ExtraProperties属性中，需要手动映射
        CreateMap<Tenant, TenantDto>()
            .ForMember(dto => dto.IsActive, opt => opt.MapFrom(t => t.GetIsActive()))
            .ForMember(dto => dto.EnableTime, opt => opt.MapFrom(t => t.GetEnableTime()))
            .ForMember(dto => dto.DisableTime, opt => opt.MapFrom(t => t.GetDisableTime()))
            .MapExtraProperties()
            .AfterMap((src, dest) =>
            {
                var propertiesToRemove = new[]
                {
                    nameof(TenantDto.IsActive),
                    nameof(TenantDto.EnableTime),
                    nameof(TenantDto.DisableTime)
                };

                foreach (var propertyName in propertiesToRemove)
                {
                    if (dest.ExtraProperties.ContainsKey(propertyName))
                    {
                        dest.ExtraProperties.Remove(propertyName);
                    }
                }
            });

        CreateMap<TenantConnectionString, TenantConnectionStringDto>();
    }
}
