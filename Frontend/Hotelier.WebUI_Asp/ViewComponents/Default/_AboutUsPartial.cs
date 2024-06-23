using Hotelier.DtoLayer.Abouts;
using Hotelier.WebUI_Asp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotelier.WebUI_Asp.ViewComponents.Default;

public class _AboutUsPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _AboutUsPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/abouts");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<AboutGetDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}