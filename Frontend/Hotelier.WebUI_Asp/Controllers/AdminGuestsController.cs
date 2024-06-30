using Hotelier.DtoLayer.Guests;
using Hotelier.WebUI_Asp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotelier.WebUI_Asp.Controllers;
public class AdminGuestsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminGuestsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/guests");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<GuestGetDto>>(jsonData);
        return View(values);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(GuestAddDto guestAdd)
    {
        if (!ModelState.IsValid)
            return View();

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(guestAdd);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PostAsync($"{Constants.BaseUrl}/guests", stringContent);

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"{Constants.BaseUrl}/guests/{id}");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/guests/{id}");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<GuestUpdateDto>(jsonData);
        return View(values);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, GuestUpdateDto guestUpdate)
    {
        if (!ModelState.IsValid)
            return View();

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(guestUpdate);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync($"{Constants.BaseUrl}/guests/{id}", stringContent);

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        return RedirectToAction("Index");
    }
}