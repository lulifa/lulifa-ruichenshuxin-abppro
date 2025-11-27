using System.Collections.Generic;
using System.Threading.Tasks;

namespace RuichenShuxin.AbpPro.Platform;

public interface IVben5NavigationManager
{
    Task<IReadOnlyCollection<ApplicationMenu>> GetAll();
}
