using MediatR;
using Microsoft.AspNetCore.Mvc;
using OsService.Application.Commands.V1.CreateCustomer;
using OsService.Application.DTOs;
using OsService.Application.Queries.V1.Customer;

namespace OsService.ApiService.Controllers;

[ApiController]
[Route("v1/customers")]
public sealed class CustomersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CustomerDto customerDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var id = await mediator.Send(new CreateCustomerCommand(customerDto.Name, customerDto.Phone, customerDto.Email, customerDto.Document), cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var customerEntity = await mediator.Send(new GetCustomerByIdQuery(id), cancellationToken);
        return Ok(customerEntity);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string? phone, [FromQuery] string? document, CancellationToken cancellationToken)
    {
        var customer = await mediator.Send(new GetCustomerByPhoneOrDocumentQuery(phone, document), cancellationToken);
        if (customer is null)
            return NotFound();

        return Ok(customer);
    }
}