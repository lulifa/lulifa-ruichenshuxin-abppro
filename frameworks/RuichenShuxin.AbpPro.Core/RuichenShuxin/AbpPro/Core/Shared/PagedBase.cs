using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using RuichenShuxin.AbpPro.Localization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RuichenShuxin.AbpPro.Core;

public class PagedBase : IValidatableObject
{
    public const int MaxPageSize = 100000;

    /// <summary>
    /// 是否分页 (默认 true)
    /// </summary>
    public bool IsPaged { get; set; } = true;

    /// <summary>
    /// 当前页码 (默认 1)
    /// </summary>
    public int PageIndex { get; set; } = 1;

    /// <summary>
    /// 每页显示数量 (默认 10，最大值 100000)
    /// </summary>
    public int PageSize { get; set; } = 10;

    /// <summary>
    /// 跳过数量
    /// </summary>
    public int SkipCount => (PageIndex - 1) * PageSize;

    /// <summary>
    /// 排序规则
    /// </summary>
    public string Sorting { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var localization = validationContext.GetRequiredService<IStringLocalizer<AbpProLocalizationResource>>();

        if (IsPaged)
        {
            if (PageIndex < 1)
            {
                yield return new ValidationResult(
                    localization[AbpProLocalizationErrorCodes.ErrorCode100001],
                    [nameof(PageIndex)]
                );
            }

            if (PageSize > MaxPageSize)
            {
                yield return new ValidationResult(
                    localization[AbpProLocalizationErrorCodes.ErrorCode100002],
                    [nameof(PageSize)]
                );
            }
        }

    }
}
