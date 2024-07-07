using Hotelier.DtoLayer.AppUsers;
using Hotelier.WebUI_Asp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotelier.WebUI_Asp.Controllers;
public class AdminUsersController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminUsersController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/appusers");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<AppUserGetDto>>(jsonData);
        return View(values);
    }


    public async Task<IActionResult> UserList()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/appusers");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<AppUserGetDto>>(jsonData);
        return View(values);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AppUserAddDto appUserAdd)
    {
        if (!ModelState.IsValid)
            return View();

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(appUserAdd);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PostAsync($"{Constants.BaseUrl}/appusers", stringContent);

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"{Constants.BaseUrl}/appusers/{id}");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/appusers/{id}");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<AppUserUpdateDto>(jsonData);
        return View(values);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, AppUserUpdateDto appUserUpdate)
    {
        if (!ModelState.IsValid)
            return View();

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(appUserUpdate);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PutAsync($"{Constants.BaseUrl}/appusers/{id}", stringContent);

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        return RedirectToAction("Index");
    }
}
