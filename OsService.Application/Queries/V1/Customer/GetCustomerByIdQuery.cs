using MediatR;
using OsService.Application.DTOs.Customer;

namespace OsService.Application.Queries.V1.Customer;

public sealed record GetCustomerByIdQuery(Guid Id) : IRequest<CustomerDto?>;