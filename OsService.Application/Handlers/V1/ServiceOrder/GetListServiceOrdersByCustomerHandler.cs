using MediatR;
using OsService.Application.Queries.V1.ServiceOrder;
using OsService.Domain.Entities;
using OsService.Domain.Repository.Interfaces.ServiceOrder;

namespace OsService.Application.Handers.V1.ServiceOrder
{
    public sealed class GetListServiceOrdersByCustomerHandler(IServiceOrderRepository repository) : IRequestHandler<GetListServiceOrdersByCustomerQuery, IEnumerable<ServiceOrderEntity?>>
    {
        public async Task<IEnumerable<ServiceOrderEntity?>> Handle(GetListServiceOrdersByCustomerQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            // Validate customer id (adjust depending on your query type)
            var customerId = request.customerId;
            if (customerId == Guid.Empty)
            {
                return Enumerable.Empty<ServiceOrderEntity?>();
            }

            // Call the repository (replace method name with the one from your interface)
            var orders = await repository.GetServiceOrdersByCustomerId(customerId, cancellationToken);

            if (orders is null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return orders.ToList();
        }
    }
}