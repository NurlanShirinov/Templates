using Application.CQRS.Product.Command.Request;
using Application.CQRS.Product.Query.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TemplateProject.Controllers;

[Route("api/[controller]/[Action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var result = new GetByIdProductRequest(id);
        return Ok(await _mediator.Send(result));
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] DeleteProductRequest request)
    {
        return Ok(_mediator.Send(request));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductRequest request)
    {
        return Ok(await _mediator.Send(request));
    }
}