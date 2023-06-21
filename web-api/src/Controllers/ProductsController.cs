using Microsoft.AspNetCore.Mvc;
using BogdaroneApp.Domain.DataAccess;
using BogdaroneApp.Domain.Models;

namespace BogdaroneApp.Controllers;

public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IRepository<Product> _productRepository;

    public ProductsController(
        ILogger<ProductsController> logger,
        IRepository<Product> productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }
    

    [HttpGet("/Products")]
    public IEnumerable<Product> Get()
    {
        return _productRepository.GetAll();
    }

    // public IActionResult Get(string Id)
    // {
    //     var product = _productRepository.GetById(Id);
    //     if (product is null) return NotFound();
    //     return Ok(product);
    // }
}
