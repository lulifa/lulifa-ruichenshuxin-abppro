using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace RuichenShuxin.AbpPro.Platform.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
