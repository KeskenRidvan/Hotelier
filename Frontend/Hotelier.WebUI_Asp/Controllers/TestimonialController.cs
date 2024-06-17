﻿using Hotelier.DtoLayer.Testimonials;
using Hotelier.WebUI_Asp.Models;
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
		var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/testimonials");

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		var jsonData = await responseMessage.Content.ReadAsStringAsync();
		var values = JsonConvert.DeserializeObject<List<TestimonialGetDto>>(jsonData);
		return View(values);
	}

	public IActionResult Add()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Add(TestimonialAddDto dto)
	{
		var client = _httpClientFactory.CreateClient();
		var jsonData = JsonConvert.SerializeObject(dto);

		StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

		var responseMessage = await client.PostAsync($"{Constants.BaseUrl}/testimonials", stringContent);

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		return RedirectToAction("Index");
	}

	public async Task<IActionResult> Delete(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.DeleteAsync($"{Constants.BaseUrl}/testimonials/{id}");

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		return RedirectToAction("Index");
	}

	public async Task<IActionResult> Update(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/testimonials/{id}");

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		var jsonData = await responseMessage.Content.ReadAsStringAsync();
		var values = JsonConvert.DeserializeObject<TestimonialUpdateDto>(jsonData);
		return View(values);
	}

	[HttpPost]
	public async Task<IActionResult> Update(int id, TestimonialUpdateDto dto)
	{
		var client = _httpClientFactory.CreateClient();
		var jsonData = JsonConvert.SerializeObject(dto);

		StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

		var responseMessage = await client.PutAsync($"{Constants.BaseUrl}/testimonials/{id}", stringContent);

		if (!responseMessage.IsSuccessStatusCode)
			return View();

		return RedirectToAction("Index");
	}
}