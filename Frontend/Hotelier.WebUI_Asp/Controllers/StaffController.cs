using Hotelier.WebUI_Asp.Models.Staffs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotelier.WebUI_Asp.Controllers;
public class StaffController : Controller
{
	private readonly IHttpClientFactory _httpClientFactory;

	public StaffController(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<IActionResult> Index()
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync("https://localhost:7094/api/staffs");

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		var jsonData = await responseMessage.Content.ReadAsStringAsync();
		var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
		return View(values);
	}
}
