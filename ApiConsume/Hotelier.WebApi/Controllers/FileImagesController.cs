﻿using Microsoft.AspNetCore.Mvc;

namespace Hotelier.WebApi.Controllers;

[Route("api/fileimages")]
[ApiController]
public class FileImagesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadImage([FromForm] FormFile file)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var path = Path.Combine(Directory.GetCurrentDirectory(), "images/" + fileName);
        var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);
        return Created("", file);
    }
}