namespace RuichenShuxin.AbpPro;

/// <summary>
/// 作者管理
/// </summary>
[Route($"api/authors")]
public class AuthorController : AbpProController<
    IAuthorAppService,
    AuthorDto,
    GetAuthorListDto,
    CreateAuthorDto,
    UpdateAuthorDto>
{
    public AuthorController(IAuthorAppService appService) : base(appService)
    {
    }
}
