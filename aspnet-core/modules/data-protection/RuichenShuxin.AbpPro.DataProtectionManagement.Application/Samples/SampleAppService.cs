using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace RuichenShuxin.AbpPro.DataProtectionManagement.Samples;

public class SampleAppService : DataProtectionManagementAppService, ISampleAppService
{
    public Task<SampleDto> GetAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }

    [Authorize]
    public Task<SampleDto> GetAuthorizedAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }
}
