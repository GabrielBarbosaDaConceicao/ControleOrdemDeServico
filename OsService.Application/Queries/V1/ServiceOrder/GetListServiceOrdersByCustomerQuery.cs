using MediatR;
using OsService.Domain.Entities;

namespace OsService.Application.Queries.V1.ServiceOrder
{
    public record class GetListServiceOrdersByCustomerQuery(CustomerEntity customerEntity) : IRequest<IEnumerable<ServiceOrderEntity>>;
}