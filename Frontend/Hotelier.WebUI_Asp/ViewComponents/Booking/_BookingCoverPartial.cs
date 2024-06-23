using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.ViewComponents.Booking;

public class _BookingCoverPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
