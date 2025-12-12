namespace Microsoft.AspNetCore.Cors;

public static class AbpProCorsPolicyBuilderExtensions
{
    public static CorsPolicyBuilder WithAbpWrapExposedHeaders(this CorsPolicyBuilder corsPolicyBuilder)
    {
        return corsPolicyBuilder
            .WithExposedHeaders(
                AbpProHttpWrapConsts.AbpWrapResult,
                AbpProHttpWrapConsts.AbpDontWrapResult);
    }
}
