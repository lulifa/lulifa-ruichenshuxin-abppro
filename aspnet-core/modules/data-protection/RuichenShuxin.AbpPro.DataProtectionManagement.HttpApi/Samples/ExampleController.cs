using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace RuichenShuxin.AbpPro.DataProtectionManagement.Samples;

[Area(DataProtectionManagementRemoteServiceConsts.ModuleName)]
[RemoteService(Name = DataProtectionManagementRemoteServiceConsts.RemoteServiceName)]
[Route("api/data-protection-management/example")]
public class ExampleController : DataProtectionManagementController, ISampleAppService
{
    private readonly ISampleAppService _sampleAppService;

    public ExampleController(ISampleAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }

    [HttpGet]
    public async Task<SampleDto> GetAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpGet]
    [Route("authorized")]
    [Authorize]
    public async Task<SampleDto> GetAuthorizedAsync()
    {
        return await _sampleAppService.GetAsync();
    }
}
