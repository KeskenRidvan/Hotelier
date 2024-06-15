using Hotelier.BusinessLayer.Abstracts;
using Hotelier.EntityLayer.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/testimonials")]
[ApiController]
public class TestimonialsController : Controller
{
	private readonly ITestimonialService _testimonialService;

	public TestimonialsController(ITestimonialService testimonialService)
	{
		_testimonialService = testimonialService;
	}

	[HttpGet("{id}")]
	public IActionResult Get([FromRoute] int id)
	{
		var response = _testimonialService.GetById(id);
		return Ok(response);
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var response = _testimonialService.GetList();
		return Ok(response);
	}

	[HttpPost]
	public IActionResult Add([FromBody] Testimonial testimonial)
	{
		_testimonialService.Insert(testimonial);
		return Ok();
	}

	[HttpDelete("{id}")]
	public IActionResult Delete([FromRoute] int id)
	{
		var response = _testimonialService.GetById(id);
		_testimonialService.Delete(response);
		return Ok();
	}

	[HttpPut("{id}")]
	public IActionResult Update([FromRoute] int id, [FromBody] Testimonial testimonial)
	{
		_testimonialService.Update(testimonial);
		return Ok();
	}
}
