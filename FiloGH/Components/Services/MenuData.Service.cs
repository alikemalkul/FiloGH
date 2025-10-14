public class MenuDataService
{
    private List<MainMenuItems> MenuData = new List<MainMenuItems>()
    {
        new MainMenuItems(
            menuTitle: "MAIN"
        ),
        new MainMenuItems(
            type: "sub",
            title: "Dashboards",
            icon: "bx bx-home",
            badgeValue: "12",
            badgeClass: "bg-warning-transparent",
            selected: false,
            active: false,
            dirChange: false,
            children: new MainMenuItems[]
            {
              new MainMenuItems (
                    path: "/index",
                    type: "link",
                    title: "CRM",
                    selected: false,
                    active: false,
                    dirChange: false
                ),
            }
        ),
        new MainMenuItems (
            type: "sub",
            title: "Error",
            icon: "bx bx-error",
            selected: false,
            active: false,
            dirChange: false,
            children: new MainMenuItems[]
            {
                new MainMenuItems (
                    path: "/error401",
                    type: "link",
                    title: "Error 401",
                    selected: false,
                    active: false,
                    dirChange: false
                ),
            }
        ),
        new MainMenuItems (
            type: "sub",
            title: "Nested Menu",
            icon: "bx bx-layer",
            selected: false,
            active: false,
            dirChange: false,
            children: new MainMenuItems[]
            {
                new MainMenuItems (
                    path: "",
                    type: "empty",
                    title: "Nested-1",
                    selected: false,
                    active: false,
                    dirChange: false
                ),
                new MainMenuItems (
                    type: "sub",
                    title: "Nested-2",
                    selected: false,
                    active: false,
                    dirChange: false,
                    children: new MainMenuItems[]
                    {
                        new MainMenuItems (
                            path: "",
                            type: "empty",
                            title: "Nested-2-1",
                            selected: false,
                            active: false,
                            dirChange: false
                        ),
                        new MainMenuItems (
                            type: "sub",
                            title: "Nested-2-2",
                            selected: false,
                            active: false,
                            dirChange: false,
                            children: new MainMenuItems[]
                            {
                                new MainMenuItems (
                                    path: "",
                                    type: "empty",
                                    title: "Nested-2-2-1",
                                    selected: false,
                                    active: false,
                                    dirChange: false
                                ),
                                new MainMenuItems (
                                    path: "",
                                    type: "empty",
                                    title: "Nested-2-2-2",
                                    selected: false,
                                    active: false,
                                    dirChange: false
                                )
                            }
                        )
                    }
                )
            }
        ),
        
        //Benden
        new MainMenuItems (
            path: "/",
            type: "link",
            title: "Ana Menü",
            //icon: "bi bi-send",
            selected: false,
            active: true,
            dirChange: false
        ),
        new MainMenuItems (
            path: "/order/1",
            type: "link",
            title: "Order",
            //icon: "bi bi-send",
            selected: false,
            active: true,
            dirChange: false
        )
    };

    public List<MainMenuItems> GetMenuData()
   {
        return MenuData;
    }
}
