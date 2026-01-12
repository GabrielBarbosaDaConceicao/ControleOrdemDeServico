using MediatR;
using Microsoft.AspNetCore.Mvc;
using OsService.Application.Commands.V1.ServiceOrder;

namespace OsService.ApiService.Controllers;

[ApiController]
[Route("v1/service-orders")]
public sealed class ServiceOrdersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Open([FromBody] OpenServiceOrderCommand command, CancellationToken cancellationToken)
    {
        var (id, number) = await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, new { id, number });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return Ok(new { id });
    }

    [HttpPatch("{id:guid}/{status}")]
    public async Task<IActionResult> GetByServiceOrderStatus(Guid id, string? status, CancellationToken cancellationToken)
    {
        return Ok(new { id });
    }

    [HttpPut("{id:guid}/{price:decimal}")]
    public async Task<IActionResult> GetByPeriod(Guid id, decimal price, CancellationToken cancellationToken)
    {
        return Ok(new { id });
    }
}