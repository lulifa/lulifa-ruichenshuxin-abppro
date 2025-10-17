using RuichenShuxin.AbpPro.Books;
using Xunit;

namespace RuichenShuxin.AbpPro.EntityFrameworkCore.Applications.Books;

[Collection(AbpProTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<AbpProEntityFrameworkCoreTestModule>
{

}