using Hotelier.DtoLayer.Staffs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
		var values = JsonConvert.DeserializeObject<List<StaffGetDto>>(jsonData);
		return View(values);
	}

	public IActionResult Add()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Add(StaffAddDto dto)
	{
		var client = _httpClientFactory.CreateClient();
		var jsonData = JsonConvert.SerializeObject(dto);

		StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

		var responseMessage = await client.PostAsync("https://localhost:7094/api/staffs", stringContent);

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		return RedirectToAction("Index");
	}

	public async Task<IActionResult> Delete(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.DeleteAsync($"https://localhost:7094/api/staffs/{id}");

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		return RedirectToAction("Index");
	}

	public async Task<IActionResult> Update(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync($"https://localhost:7094/api/staffs/{id}");

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		var jsonData = await responseMessage.Content.ReadAsStringAsync();
		var values = JsonConvert.DeserializeObject<StaffUpdateDto>(jsonData);
		return View(values);
	}

	[HttpPost]
	public async Task<IActionResult> Update(int id, StaffUpdateDto dto)
	{
		var client = _httpClientFactory.CreateClient();
		var jsonData = JsonConvert.SerializeObject(dto);

		StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

		var responseMessage = await client.PutAsync($"https://localhost:7094/api/staffs/{id}", stringContent);

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		return RedirectToAction("Index");
	}
}
