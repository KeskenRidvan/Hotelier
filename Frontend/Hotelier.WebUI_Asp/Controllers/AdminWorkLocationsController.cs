using Hotelier.DtoLayer.WorkLocations;
using Hotelier.WebUI_Asp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotelier.WebUI_Asp.Controllers;
public class AdminWorkLocationsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminWorkLocationsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/worklocations");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<WorkLocationGetDto>>(jsonData);
        return View(values);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(WorkLocationAddDto workLocationAdd)
    {
        if (!ModelState.IsValid)
            return View();

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(workLocationAdd);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PostAsync($"{Constants.BaseUrl}/worklocations", stringContent);

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"{Constants.BaseUrl}/worklocations/{id}");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/worklocations/{id}");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<WorkLocationUpdateDto>(jsonData);
        return View(values);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, WorkLocationUpdateDto workLocationUpdate)
    {
        if (!ModelState.IsValid)
            return View();

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(workLocationUpdate);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync($"{Constants.BaseUrl}/worklocations/{id}", stringContent);

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        return RedirectToAction("Index");
    }
}