using Application.CQRS.Product.Command.Request;
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
}
