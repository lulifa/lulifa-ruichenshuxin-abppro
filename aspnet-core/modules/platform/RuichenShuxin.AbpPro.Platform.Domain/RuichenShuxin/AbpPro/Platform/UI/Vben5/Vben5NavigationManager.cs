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
        navigationDefineitions.AddRange(GetPlatform());

        foreach (var navigationDefineition in navigationDefineitions)
        {
            navigations.Add(navigationDefineition.Menu);
        }

        IReadOnlyCollection<ApplicationMenu> menus = navigations.ToImmutableList();

        return Task.FromResult(menus);
    }


    private static NavigationDefinition[] GetVbenDemos()
    {
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
            new NavigationDefinition(about),
        ];
    }

    private static NavigationDefinition[] GetDashboard()
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
               name: "Vben5Workbench",
               displayName: "工作台",
               url: "/workspace",
               component: "/dashboard/workspace/index",
               icon: "carbon:workspace",
               description: "工作台")
           .SetProperty("affixTab", "true")
           .SetProperty("title", "page.dashboard.workspace")
        );

        dashboard.AddItem(
            new ApplicationMenu(
                name: "Vben5Analysis",
                displayName: "分析页",
                url: "/analytics",
                component: "/dashboard/analytics/index",
                icon: "lucide:area-chart",
                description: "分析页")
            .SetProperty("title", "page.dashboard.analytics")
         );

        return
        [
            new NavigationDefinition(dashboard),
        ];
    }

    private static NavigationDefinition[] GetSaas()
    {
        var saas = new ApplicationMenu(
            name: "Vben5System",
            displayName: "系统管理",
            url: "/system",
            component: "",
            description: "系统管理",
            icon: "arcticons:activity-manager",
            multiTenancySides: MultiTenancySides.Host)
            .SetProperty("title", "abp.system.title");
        saas.AddItem(
          new ApplicationMenu(
              name: "Vben5SystemTenants",
              displayName: "租户管理",
              url: "/system/tenants",
              component: "/system/tenants/index",
              icon: "arcticons:tenantcloud-pro",
              description: "租户管理",
              multiTenancySides: MultiTenancySides.Host)
            .SetProperty("title", "abp.system.tenants"));

        return
        [
            new NavigationDefinition(saas),
        ];
    }

    private static NavigationDefinition[] GetPlatform()
    {
        var platform = new ApplicationMenu(
            name: "Vben5Platform",
            displayName: "平台管理",
            url: "/platform",
            component: "",
            description: "平台管理",
            icon: "ep:platform")
            .SetProperty("title", "abp.platform.title");
        platform.AddItem(
          new ApplicationMenu(
              name: "Vben5PlatformMenus",
              displayName: "菜单管理",
              url: "/platform/menus",
              component: "/platform/menus/index",
              icon: "material-symbols-light:menu",
              description: "菜单管理")
            .SetProperty("title", "abp.platform.menus"));
        platform.AddItem(
          new ApplicationMenu(
              name: "Vben5PlatformLayouts",
              displayName: "布局管理",
              url: "/platform/layouts",
              component: "/platform/layouts/index",
              icon: "material-symbols-light:responsive-layout",
              description: "布局管理")
            .SetProperty("title", "abp.platform.layouts"));
        platform.AddItem(
          new ApplicationMenu(
              name: "Vben5PlatformDataDictionaries",
              displayName: "数据字典",
              url: "/platform/data-dictionaries",
              component: "/platform/data-dictionaries/index",
              icon: "material-symbols:dictionary-outline",
              description: "数据字典")
            .SetProperty("title", "abp.platform.dataDictionaries"));

        return
        [
            new NavigationDefinition(platform),
        ];
    }

}
