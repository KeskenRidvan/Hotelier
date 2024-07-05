using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DtoLayer.SendMessages;
using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/sendmessages")]
[ApiController]
public class SendMessagesController : ControllerBase
{
    private readonly ISendMessageService _sendMessageService;

    public SendMessagesController(ISendMessageService sendMessageService)
    {
        _sendMessageService = sendMessageService;
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var response = _sendMessageService.GetById(id);
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var response = _sendMessageService.GetList();
        return Ok(response);
    }

    [HttpGet("getsendmessagecount")]
    public IActionResult GetSendMessageCount()
    {
        return Ok(_sendMessageService.GetSendMessageCount());
    }

    [HttpPost]
    public IActionResult Add([FromBody] SendMessageAddDto sendMessageAddDto)
    {
        _sendMessageService.Insert(sendMessageAddDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _sendMessageService.Delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        [FromRoute] int id,
        [FromBody] SendMessageUpdateDto sendMessageUpdateDto)
    {
        _sendMessageService.Update(sendMessageUpdateDto);
        return Ok();
    }
}
