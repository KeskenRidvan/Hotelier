using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DtoLayer.Testimonials;
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
    public IActionResult Add([FromBody] TestimonialAddDto testimonialAddDto)
    {
        _testimonialService.Insert(testimonialAddDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _testimonialService.Delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        [FromRoute] int id,
        [FromBody] TestimonialUpdateDto testimonialUpdateDto)
    {
        _testimonialService.Update(testimonialUpdateDto);
        return Ok();
    }
}