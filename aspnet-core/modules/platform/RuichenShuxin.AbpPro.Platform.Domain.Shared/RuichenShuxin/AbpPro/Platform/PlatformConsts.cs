namespace RuichenShuxin.AbpPro.Platform;

public static class PlatformConsts
{
    /// <summary>
    /// 编号不足位补足字符，如编号为 3，长度5位，补足字符为 0，则编号为00003
    /// </summary>
    public static char CodePrefix { get; set; } = '0';
    /// <summary>
    /// 编号长度
    /// </summary>
    public const int CodeUnitLength = 5;

    /// <summary>
    /// 最大深度
    /// </summary>
    /// <remarks>
    /// 默认为4,仅支持四级子菜单
    /// </remarks>
    public const int MaxDepth = 4;

    public const int MaxCodeLength = MaxDepth * (CodeUnitLength + 1) - 1;

}
