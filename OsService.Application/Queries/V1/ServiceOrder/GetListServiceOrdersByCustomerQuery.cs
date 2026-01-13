using MediatR;
using OsService.Application.DTOs;
using OsService.Domain.Entities;

namespace OsService.Application.Queries.V1.ServiceOrder
{
    public record class GetListServiceOrdersByCustomerQuery(Guid customerId) : IRequest<IEnumerable<ServiceOrderEntity>>;
}