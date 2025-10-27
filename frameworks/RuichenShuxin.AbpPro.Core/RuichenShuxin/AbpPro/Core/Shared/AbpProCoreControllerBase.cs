namespace RuichenShuxin.AbpPro.Core;

/// <summary>
/// Controller 基类（最顶层，定义资源类型）
/// </summary>
[AbpProCoreWrapResult]
public abstract class AbpProCoreControllerBase<TResource> : AbpControllerBase
    where TResource : class
{
    protected AbpProCoreControllerBase()
    {
        LocalizationResource = typeof(TResource);
    }
}

/// <summary>
/// 通用的 CRUD Controller 基类（支持任意主键类型）
/// </summary>
public abstract class AbpProCoreCrudControllerBase<
    TAppService,
    TEntityDto,
    TKey,
    TGetListInput,
    TCreateUpdateInput,
    TResource>
    : AbpProCoreControllerBase<TResource>
    where TAppService : ICrudAppService<TEntityDto, TKey, TGetListInput, TCreateUpdateInput>
    where TResource : class
{
    protected readonly TAppService AppService;

    protected AbpProCoreCrudControllerBase(TAppService appService)
    {
        AppService = appService;
    }

    [HttpPost]
    public virtual Task<TEntityDto> CreateAsync(TCreateUpdateInput input)
        => AppService.CreateAsync(input);

    [HttpPut("{id}")]
    public virtual Task<TEntityDto> UpdateAsync(TKey id, TCreateUpdateInput input)
        => AppService.UpdateAsync(id, input);

    [HttpDelete("{id}")]
    public virtual Task DeleteAsync(TKey id)
        => AppService.DeleteAsync(id);

    [HttpGet("{id}")]
    public virtual Task<TEntityDto> GetAsync(TKey id)
        => AppService.GetAsync(id);

    [HttpGet]
    public virtual Task<PagedResultDto<TEntityDto>> GetListAsync(TGetListInput input)
        => AppService.GetListAsync(input);
}

/// <summary>
/// 默认使用 Guid 主键的 CRUD Controller 基类
/// </summary>
public abstract class AbpProCoreCrudControllerBaseWithGuid<
    TAppService,
    TEntityDto,
    TGetListInput,
    TCreateUpdateInput,
    TResource>
    : AbpProCoreCrudControllerBase<
        TAppService,
        TEntityDto,
        Guid,
        TGetListInput,
        TCreateUpdateInput,
        TResource>
    where TAppService : ICrudAppService<TEntityDto, Guid, TGetListInput, TCreateUpdateInput>
    where TResource : class
{
    protected AbpProCoreCrudControllerBaseWithGuid(TAppService appService)
        : base(appService)
    {
    }
}

