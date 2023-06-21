using Microsoft.AspNetCore.Mvc;
using BogdaroneApp.Domain.DataAccess;
using BogdaroneApp.Domain.Models;

namespace BogdaroneApp.Controllers;

public class ImagesController : ControllerBase
{
    private readonly ILogger<ImagesController> _logger;
    private readonly IRepository<Image> _imageRepository;

    public ImagesController(
        ILogger<ImagesController> logger,
        IRepository<Image> imageRepository)
    {
        _logger = logger;
        _imageRepository = imageRepository;
    }
    

    [HttpGet("/Images/{id}")]
    public IActionResult Get(string Id)
    {
        Image? image = _imageRepository.GetById(Id);
        if (image is null) return NotFound();
        if (image is null) return StatusCode(500);
        return new FileContentResult(image.Bytes!, "image/jpeg");
    }
}