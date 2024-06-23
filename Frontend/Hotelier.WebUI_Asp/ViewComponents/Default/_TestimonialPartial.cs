﻿using Hotelier.DtoLayer.Testimonials;
using Hotelier.WebUI_Asp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotelier.WebUI_Asp.ViewComponents.Default;

public class _TestimonialPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _TestimonialPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{Constants.BaseUrl}/testimonials");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<TestimonialGetDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}