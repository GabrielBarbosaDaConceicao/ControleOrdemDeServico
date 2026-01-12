using MediatR;

namespace OsService.Application.Commands.V1.CreateCustomer;

public sealed record CreateCustomerCommand(
    string Name,
    string? Phone,
    string? Email,
    string? Document
) : IRequest<Guid>;
