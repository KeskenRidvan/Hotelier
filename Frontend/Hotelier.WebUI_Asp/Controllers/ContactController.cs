using Hotelier.DtoLayer.Contacts;
using Hotelier.WebUI_Asp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotelier.WebUI_Asp.Controllers;
public class ContactController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ContactController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public PartialViewResult SendMessage()
    {
        return PartialView();
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(ContactAddDto contactAdd)
    {
        if (!ModelState.IsValid)
            return View();

        contactAdd.Date = DateTime.Parse(DateTime.Now.ToString());

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(contactAdd);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        await client.PostAsync($"{Constants.BaseUrl}/contacts", stringContent);
        return RedirectToAction("Index", "Default");
    }
}
