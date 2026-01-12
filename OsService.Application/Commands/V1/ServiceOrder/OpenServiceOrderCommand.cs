using MediatR;

namespace OsService.Application.Commands.V1.ServiceOrder;

public sealed record OpenServiceOrderCommand(Guid CustomerId, string Description) : IRequest<(Guid Id, int Number)>;