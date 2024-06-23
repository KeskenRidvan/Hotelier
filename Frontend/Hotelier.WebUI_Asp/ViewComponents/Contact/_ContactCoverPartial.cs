using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.ViewComponents.Contact;

public class _ContactCoverPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
