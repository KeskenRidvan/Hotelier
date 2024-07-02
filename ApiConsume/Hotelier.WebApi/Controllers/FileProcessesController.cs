using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;
[Route("api/fileprocesses")]
[ApiController]
public class FileProcessesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var path = Path.Combine(Directory.GetCurrentDirectory(), "files/" + fileName);
        var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);

        return Created("", file);
    }
}