using MediatR;
using OsService.Application.Queries.V1.ServiceOrder;
using OsService.Domain.Entities;
using OsService.Domain.Repository.Interfaces.ServiceOrder;

namespace OsService.Application.Handers.V1.ServiceOrder
{
    public sealed class GetListServiceOrdersByCustomerHandler(IServiceOrderRepository repository) : IRequestHandler<GetListServiceOrdersByCustomerQuery, IEnumerable<ServiceOrderEntity?>>
    {
        public Task<IEnumerable<ServiceOrderEntity?>> Handle(GetListServiceOrdersByCustomerQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}