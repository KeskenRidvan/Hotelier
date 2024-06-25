using Hotelier.DtoLayer.Bookings;
using Hotelier.WebUI_Asp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotelier.WebUI_Asp.Controllers;
public class AdminBookingController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminBookingController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/bookings");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<BookingGetDto>>(jsonData);
        return View(values);
    }

    public async Task<IActionResult> ReservationStatusApproved(int id)
    {
        var client = _httpClientFactory.CreateClient();

        BookingUpdateStatus updateStatus = new();

        updateStatus.BookingID = id;
        updateStatus.Status = "Onaylandi";

        var jsonData = JsonConvert.SerializeObject(updateStatus);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync($"{Constants.BaseUrl}/bookings/status/{id}", stringContent);

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> ReservationStatusCancelled(int id)
    {
        var client = _httpClientFactory.CreateClient();

        BookingUpdateStatus updateStatus = new();

        updateStatus.BookingID = id;
        updateStatus.Status = "Iptal Edildi";

        var jsonData = JsonConvert.SerializeObject(updateStatus);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync($"{Constants.BaseUrl}/bookings/status/{id}", stringContent);

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        return RedirectToAction("Index");
    }
    public async Task<IActionResult> ReservationStatusHold(int id)
    {
        var client = _httpClientFactory.CreateClient();

        BookingUpdateStatus updateStatus = new();

        updateStatus.BookingID = id;
        updateStatus.Status = "Onay Bekliyor";

        var jsonData = JsonConvert.SerializeObject(updateStatus);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync($"{Constants.BaseUrl}/bookings/status/{id}", stringContent);

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        return RedirectToAction("Index");
    }
}