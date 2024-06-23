using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DtoLayer.MessageCategories;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/messagecategories")]
[ApiController]
public class MessageCategoriesController : ControllerBase
{
    private readonly IMessageCategoryService _messageCategoryService;

    public MessageCategoriesController(IMessageCategoryService messageCategoryService)
    {
        _messageCategoryService = messageCategoryService;
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var response = _messageCategoryService.GetById(id);
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var response = _messageCategoryService.GetList();
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Add([FromBody] MessageCategoryAddDto messageCategoryAddDto)
    {
        _messageCategoryService.Insert(messageCategoryAddDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _messageCategoryService.Delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        [FromRoute] int id,
        [FromBody] MessageCategoryUpdateDto messageCategoryUpdateDto)
    {
        _messageCategoryService.Update(messageCategoryUpdateDto);
        return Ok();
    }
}
