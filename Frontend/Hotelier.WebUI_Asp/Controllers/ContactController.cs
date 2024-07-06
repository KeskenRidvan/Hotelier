using Hotelier.DtoLayer.Contacts;
using Hotelier.DtoLayer.MessageCategories;
using Hotelier.WebUI_Asp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Hotelier.WebUI_Asp.Controllers;

[AllowAnonymous]
public class ContactController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ContactController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/messagecategories");

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<MessageCategoryGetDto>>(jsonData);

        List<SelectListItem> values2 =
            values.Select(x => new SelectListItem
            {
                Text = x.MessageCategoryName,
                Value = x.MessageCategoryID.ToString()
            }).ToList();

        ViewBag.messageCategories = values2;

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
