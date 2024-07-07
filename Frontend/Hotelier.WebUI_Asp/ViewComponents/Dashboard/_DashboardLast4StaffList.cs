using Hotelier.DtoLayer.Staffs;
using Hotelier.WebUI_Asp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotelier.WebUI_Asp.ViewComponents.Dashboard;

public class _DashboardLast4StaffList : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private string url = "dashboardwidgets";
    public _DashboardLast4StaffList(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/{url}/last4staff");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<StaffGetDto>>(jsonData);

        return View(values);
    }
}
