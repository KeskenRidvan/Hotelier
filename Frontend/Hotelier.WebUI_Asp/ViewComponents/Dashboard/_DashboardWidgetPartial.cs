using Hotelier.WebUI_Asp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebUI_Asp.ViewComponents.Dashboard;

public class _DashboardWidgetPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private string url = "dashboardwidgets";
    public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var staffClient = _httpClientFactory.CreateClient();
        var staffResponseMessage = await staffClient.GetAsync($"{Constants.BaseUrl}/{url}/staffcount");
        var staffCountJsonData = await staffResponseMessage.Content.ReadAsStringAsync();
        ViewBag.staffCount = staffCountJsonData;

        var bookingClient = _httpClientFactory.CreateClient();
        var bookingResponseMessage = await bookingClient.GetAsync($"{Constants.BaseUrl}/{url}/bookingcount");
        var bookingCountJsonData = await bookingResponseMessage.Content.ReadAsStringAsync();
        ViewBag.bookingCount = bookingCountJsonData;

        var appUserClient = _httpClientFactory.CreateClient();
        var appUserResponseMessage = await appUserClient.GetAsync($"{Constants.BaseUrl}/{url}/appusercount");
        var appUserCountJsonData = await appUserResponseMessage.Content.ReadAsStringAsync();
        ViewBag.appUserCount = appUserCountJsonData;

        var roomClient = _httpClientFactory.CreateClient();
        var roomResponseMessage = await roomClient.GetAsync($"{Constants.BaseUrl}/{url}/roomcount");
        var roomCountJsonData = await roomResponseMessage.Content.ReadAsStringAsync();
        ViewBag.roomCount = roomCountJsonData;

        return View();
    }
}