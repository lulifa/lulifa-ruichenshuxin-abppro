namespace RuichenShuxin.AbpPro.Platform;

[Route("api/platform/layouts")]
public class LayoutController : PlatformController<
    ILayoutAppService,
    LayoutDto,
    GetLayoutListInput,
    LayoutCreateDto,
    LayoutUpdateDto>
{
    public LayoutController(ILayoutAppService appService) : base(appService)
    {
    }

    [HttpGet]
    [Route("all")]
    public async virtual Task<ListResultDto<LayoutDto>> GetAllListAsync()
    {
        return await AppService.GetAllListAsync();
    }

}
