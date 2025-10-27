using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace RuichenShuxin.AbpPro.Language.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
