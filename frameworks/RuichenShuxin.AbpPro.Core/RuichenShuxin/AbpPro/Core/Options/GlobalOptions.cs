using System;

namespace RuichenShuxin.AbpPro.Core;

public class GlobalOptions
{
    public string[] Scopes { get; set; } = Array.Empty<string>();
    public string Test { get; set; }
}
