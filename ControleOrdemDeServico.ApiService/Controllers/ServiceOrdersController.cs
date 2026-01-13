using MediatR;
using Microsoft.AspNetCore.Mvc;
using OsService.Application.Commands.V1.ServiceOrder;
using OsService.Application.Queries.V1.ServiceOrder;

namespace OsService.ApiService.Controllers;

[ApiController]
[Route("v1/service-orders")]
public sealed class ServiceOrdersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Open([FromBody] OpenServiceOrderCommand command, CancellationToken cancellationToken)
    {
        var (id, number) = await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetServiceOrderById), new { id }, new { id, number });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetServiceOrderById(Guid id, CancellationToken cancellationToken)
    {
        var serviceOrder = await mediator.Send(new GetServiceOrderByIdQuery(id), cancellationToken);
        return Ok(serviceOrder);
    }

    [HttpGet("list/{customerId:guid}")]
    public async Task<IActionResult> ListServiceOrdersByCustomer(Guid customerId, CancellationToken cancellationToken) 
    {
        var serviceOrders = await mediator.Send(new GetListServiceOrdersByCustomerQuery(customerId), cancellationToken);
        return Ok(serviceOrders);
    }
}