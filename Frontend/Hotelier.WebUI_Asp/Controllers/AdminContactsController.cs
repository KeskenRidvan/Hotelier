using Hotelier.DtoLayer.Contacts;
using Hotelier.DtoLayer.SendMessages;
using Hotelier.WebUI_Asp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotelier.WebUI_Asp.Controllers;

public class AdminContactsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminContactsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Inbox()
    {
        var contactClient = _httpClientFactory.CreateClient();
        var responseMessage = await contactClient.GetAsync($"{Constants.BaseUrl}/contacts");

        var sendMessageClient = _httpClientFactory.CreateClient();
        var getSendMessageCount = await sendMessageClient.GetAsync($"{Constants.BaseUrl}/sendmessages/getsendmessagecount");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        var contactJsonData = await responseMessage.Content.ReadAsStringAsync();
        var sendMessageJsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ContactGetDto>>(contactJsonData);
        ViewBag.contactCount = values is not null ? values.ToList().Count() : 0;
        ViewBag.sendMessageCount = sendMessageJsonData;
        return View(values);
    }

    [HttpGet]
    public async Task<IActionResult> Sendbox()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/sendmessages");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<SendMessageGetDto>>(jsonData);
        return View(values);
    }

    public async Task<IActionResult> MessageDetailsBySendbox(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/sendmessages/{id}");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<ContactGetDto>(jsonData);
        return View(values);
    }

    public async Task<IActionResult> MessageDetailsByInbox(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/contacts/{id}");

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<ContactGetDto>(jsonData);
        return View(values);
    }

    [HttpGet]
    public IActionResult AddSendMessage()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddSendMessage(SendMessageAddDto sendMessageAdd)
    {
        sendMessageAdd.SenderMail = "admin@gmail.com";
        sendMessageAdd.SenderName = "admin";
        sendMessageAdd.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

        if (!ModelState.IsValid)
            return View();

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(sendMessageAdd);

        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var responseMessage = await client.PostAsync($"{Constants.BaseUrl}/sendmessages", stringContent);

        if (!responseMessage.IsSuccessStatusCode)
            return View();

        return RedirectToAction("Index");
    }
    public PartialViewResult SideBarAdminContactPartial()
    {
        return PartialView();
    }
    public PartialViewResult SideBarAdminContactCategoryPartial()
    {
        return PartialView();
    }
}
