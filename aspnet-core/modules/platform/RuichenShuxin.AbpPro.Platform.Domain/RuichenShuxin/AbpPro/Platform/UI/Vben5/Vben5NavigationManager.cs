using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace RuichenShuxin.AbpPro.Platform;

public class Vben5NavigationManager : IVben5NavigationManager, ISingletonDependency
{
    public Vben5NavigationManager()
    {

    }

    public virtual Task<IReadOnlyCollection<ApplicationMenu>> GetAll()
    {
        var navigations = new List<ApplicationMenu>();

        var navigationDefineitions = new List<NavigationDefinition>();

        navigationDefineitions.AddRange(GetVbenDemos());
        navigationDefineitions.AddRange(GetDashboard());
        navigationDefineitions.AddRange(GetSaas());

        foreach (var navigationDefineition in navigationDefineitions)
        {
            navigations.Add(navigationDefineition.Menu);
        }

        IReadOnlyCollection<ApplicationMenu> menus = navigations.ToImmutableList();

        return Task.FromResult(menus);
    }


    private static NavigationDefinition[] GetVbenDemos()
    {
        var project = new ApplicationMenu(
            name: "VbenProject",
            displayName: "项目",
            url: "/vben-admin",
            component: "",
            description: "项目",
            order: 9998,
            icon: "https://unpkg.com/@vbenjs/static-source@0.1.7/source/logo-v1.webp")
            .SetProperty("badgeType", "dot")
            .SetProperty("title", "demos.vben.title");
        project.AddItem(
            new ApplicationMenu(
                name: "VbenDocument",
                displayName: "文档",
                url: "/vben-admin/document",
                component: "",
                icon: "lucide:book-open-text",
                description: "文档")
            .SetProperty("link", "https://doc.vben.pro")
            .SetProperty("title", "demos.vben.document")
         );
        project.AddItem(
            new ApplicationMenu(
                name: "VbenGithub",
                displayName: "Github",
                url: "/vben-admin/github",
                component: "",
                icon: "mdi:github",
                description: "Github")
            .SetProperty("link", "https://github.com/vbenjs/vue-vben-admin")
            .SetProperty("title", "Github")
         );
        project.AddItem(
            new ApplicationMenu(
                name: "VbenNaive",
                displayName: "Naive UI 版本",
                url: "/vben-admin/naive",
                component: "",
                icon: "logos:naiveui",
                description: "Naive UI 版本")
            .SetProperty("badgeType", "dot")
            .SetProperty("link", "https://naive.vben.pro")
            .SetProperty("title", "demos.vben.naive-ui")
         );
        project.AddItem(
            new ApplicationMenu(
                name: "VbenElementPlus",
                displayName: "Element Plus 版本",
                url: "/vben-admin/ele",
                component: "",
                icon: "logos:element",
                description: "Element Plus 版本")
            .SetProperty("badgeType", "dot")
            .SetProperty("link", "https://ele.vben.pro")
            .SetProperty("title", "demos.vben.element-plus")
         );

        var about = new ApplicationMenu(
            name: "VbenAbout",
            displayName: "关于",
            url: "/vben-admin/about",
            component: "/_core/about/index",
            description: "关于",
            order: 9999,
            icon: "lucide:copyright")
            .SetProperty("title", "demos.vben.about");

        return
        [
            new NavigationDefinition(project),
            new NavigationDefinition(about),
        ];
    }

    private static NavigationDefinition GetDashboard()
    {
        var dashboard = new ApplicationMenu(
            name: "Vben5Dashboard",
            displayName: "仪表盘",
            url: "/dashboard",
            component: "",
            description: "仪表盘",
            icon: "lucide:layout-dashboard",
            order: -1)
            .SetProperty("title", "page.dashboard.title");

        dashboard.AddItem(
            new ApplicationMenu(
                name: "Vben5Analysis",
                displayName: "分析页",
                url: "/analytics",
                component: "/dashboard/analytics/index",
                icon: "lucide:area-chart",
                description: "分析页")
            .SetProperty("affixTab", "true")
            .SetProperty("title", "page.dashboard.analytics")
         );

        dashboard.AddItem(
           new ApplicationMenu(
               name: "Vben5Workbench",
               displayName: "工作台",
               url: "/workspace",
               component: "/dashboard/workspace/index",
               icon: "carbon:workspace",
               description: "工作台")
           .SetProperty("title", "page.dashboard.workspace")
        );

        return new NavigationDefinition(dashboard);
    }

    private static NavigationDefinition GetSaas()
    {
        var saas = new ApplicationMenu(
            name: "Vben5Saas",
            displayName: "Saas",
            url: "/saas",
            component: "",
            description: "Saas",
            icon: "ant-design:cloud-server-outlined",
            multiTenancySides: MultiTenancySides.Host)
            .SetProperty("title", "abp.saas.title");
        saas.AddItem(
          new ApplicationMenu(
              name: "Vben5SaasTenants",
              displayName: "租户管理",
              url: "/saas/tenants",
              component: "/saas/tenants/index",
              icon: "arcticons:tenantcloud-pro",
              description: "租户管理",
              multiTenancySides: MultiTenancySides.Host)
            .SetProperty("title", "abp.saas.tenants"));

        return new NavigationDefinition(saas);
    }

}
