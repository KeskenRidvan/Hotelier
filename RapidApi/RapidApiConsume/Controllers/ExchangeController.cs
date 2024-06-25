
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers;
public class ExchangeController : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
            Headers =
            {
                { "x-rapidapi-key", "1975417f95msh7580dc05c4c84e0p175f10jsn69314a0dd888" },
                { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
            return View(values.data.exchange_rates.ToList());
        }
    }
}