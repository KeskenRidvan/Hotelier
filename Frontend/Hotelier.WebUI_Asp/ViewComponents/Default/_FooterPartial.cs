using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.ViewComponents.Default;

public class _FooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}