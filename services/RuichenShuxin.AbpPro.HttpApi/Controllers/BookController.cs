using Microsoft.AspNetCore.Mvc;
using RuichenShuxin.AbpPro.Books;
using Volo.Abp.Application.Dtos;

namespace RuichenShuxin.AbpPro;

[Route("api/books")]
public class BookController : AbpProController<
    IBookAppService,
    BookDto,
    PagedAndSortedResultRequestDto,
    CreateUpdateBookDto>
{
    public BookController(IBookAppService appService) : base(appService)
    {
    }
}
