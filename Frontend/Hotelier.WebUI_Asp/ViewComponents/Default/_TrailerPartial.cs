using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.ViewComponents.Default;

public class _TrailerPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}