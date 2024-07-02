using Hotelier.WebUI_Asp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Hotelier.WebUI_Asp.Controllers;
public class AdminFilesController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(IFormFile file)
    {
        var stream = new MemoryStream();
        await file.CopyToAsync(stream);
        var bytes = stream.ToArray();

        ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
        byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

        MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
        multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);

        var httpclient = new HttpClient();
        await httpclient.PostAsync($"{Constants.BaseUrl}/FileProcess", multipartFormDataContent);

        return View();
    }
}
