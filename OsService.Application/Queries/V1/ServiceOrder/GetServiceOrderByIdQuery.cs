using MediatR;
using OsService.Domain.Entities;

namespace OsService.Application.Queries.V1.ServiceOrder;

public sealed record GetServiceOrderByIdQuery(Guid Id) : IRequest<ServiceOrderEntity?>;