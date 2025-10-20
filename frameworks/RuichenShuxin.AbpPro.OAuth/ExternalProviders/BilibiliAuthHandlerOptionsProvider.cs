using AspNet.Security.OAuth.Bilibili;
using System;
using System.Threading.Tasks;
using Volo.Abp.Settings;

namespace RuichenShuxin.AbpPro.OAuth;

public class BilibiliAuthHandlerOptionsProvider : OAuthHandlerOptionsProvider<BilibiliAuthenticationOptions>
{
    public BilibiliAuthHandlerOptionsProvider(ISettingProvider settingProvider) : base(settingProvider)
    {
    }

    public async override Task SetOptionsAsync(BilibiliAuthenticationOptions options)
    {
        var clientId = await SettingProvider.GetOrNullAsync(AbpProOAuthSettingNames.Bilibili.ClientId);
        var clientSecret = await SettingProvider.GetOrNullAsync(AbpProOAuthSettingNames.Bilibili.ClientSecret);

        if (!clientId.IsNullOrWhiteSpace())
        {
            options.ClientId = clientId;
        }
        if (!clientSecret.IsNullOrWhiteSpace())
        {
            options.ClientSecret = clientSecret;
        }
    }
}
