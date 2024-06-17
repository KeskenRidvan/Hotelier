using Hotelier.WebUI_Asp.Models.Testimonials;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotelier.WebUI_Asp.Controllers;
public class TestimonialController : Controller
{
	private readonly IHttpClientFactory _httpClientFactory;

	public TestimonialController(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<IActionResult> Index()
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync("https://localhost:7094/api/testimonials");

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		var jsonData = await responseMessage.Content.ReadAsStringAsync();
		var values = JsonConvert.DeserializeObject<List<ViewModel>>(jsonData);
		return View(values);
	}

	[HttpGet]
	public IActionResult Add()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Add(AddViewModel model)
	{
		var client = _httpClientFactory.CreateClient();
		var jsonData = JsonConvert.SerializeObject(model);

		StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

		var responseMessage = await client.PostAsync("https://localhost:7094/api/testimonials", stringContent);

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		return RedirectToAction("Index");
	}

	public async Task<IActionResult> Delete(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.DeleteAsync($"https://localhost:7094/api/testimonials/{id}");

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		return RedirectToAction("Index");
	}

	[HttpGet]
	public async Task<IActionResult> Update(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync($"https://localhost:7094/api/testimonials/{id}");

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		var jsonData = await responseMessage.Content.ReadAsStringAsync();
		var values = JsonConvert.DeserializeObject<UpdateViewModel>(jsonData);
		return View(values);
	}

	[HttpPost]
	public async Task<IActionResult> Update(int id, UpdateViewModel model)
	{
		var client = _httpClientFactory.CreateClient();
		var jsonData = JsonConvert.SerializeObject(model);

		StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

		var responseMessage = await client.PutAsync($"https://localhost:7094/api/testimonials/{id}", stringContent);

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		return RedirectToAction("Index");
	}
}
