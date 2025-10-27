using RuichenShuxin.AbpPro.Core;
using System;
using Volo.Abp.Application.Services;

namespace RuichenShuxin.AbpPro;

/// <summary>
/// 通用 Controller 基类（所有 API 控制器都继承这个）
/// </summary>
public abstract class AbpProController : AbpProCoreControllerBase<AbpProResource>
{
}

/// <summary>
/// 通用 CRUD Controller（支持任意主键类型）
/// </summary>
public abstract class AbpProController<
    TAppService,
    TEntityDto,
    TKey,
    TGetListInput,
    TCreateUpdateInput>
    : AbpProCoreCrudControllerBase<
        TAppService,
        TEntityDto,
        TKey,
        TGetListInput,
        TCreateUpdateInput,
        AbpProResource>
    where TAppService : ICrudAppService<TEntityDto, TKey, TGetListInput, TCreateUpdateInput>
{
    protected AbpProController(TAppService appService)
        : base(appService)
    {
    }
}

/// <summary>
/// 默认 Guid 主键的通用 CRUD Controller
/// </summary>
public abstract class AbpProController<
    TAppService,
    TEntityDto,
    TGetListInput,
    TCreateUpdateInput>
    : AbpProCoreCrudControllerBaseWithGuid<
        TAppService,
        TEntityDto,
        TGetListInput,
        TCreateUpdateInput,
        AbpProResource>
    where TAppService : ICrudAppService<TEntityDto, Guid, TGetListInput, TCreateUpdateInput>
{
    protected AbpProController(TAppService appService)
        : base(appService)
    {
    }
}
