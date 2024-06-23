using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.ViewComponents.Default;

public class _ScriptsPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}