namespace RuichenShuxin.AbpPro;

/// <summary>
/// 书籍管理
/// 🚢🌞🌛✨
/// </summary>
[Route("api/books")]
public class BookController : AbpProController<
    IBookAppService,
    BookDto,
    PagedAndSortedResultRequestDto,
    CreateUpdateBookDto,
    CreateUpdateBookDto>
{
    public BookController(IBookAppService appService) : base(appService)
    {
    }
}
