using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.ViewComponents.Dashboard;

public class _DashboardHeadPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
