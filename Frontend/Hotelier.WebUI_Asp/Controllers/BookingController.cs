using Hotelier.DtoLayer.Bookings;
using Hotelier.WebUI_Asp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotelier.WebUI_Asp.Controllers;
public class BookingController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public BookingController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public PartialViewResult Add()
    {
        return PartialView();
    }

    [HttpPost]
    public async Task<IActionResult> Add(BookingAddDto bookingAdd)
    {
        if (!ModelState.IsValid)
            return View();

        bookingAdd.Status = "Onay Bekliyor";
        bookingAdd.Description = bookingAdd.SpecialRequest;

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(bookingAdd);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        await client.PostAsync($"{Constants.BaseUrl}/bookings", stringContent);
        return RedirectToAction("Index", "Default");
    }
}
