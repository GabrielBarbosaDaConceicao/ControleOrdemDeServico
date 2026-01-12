using MediatR;
using OsService.Application.Queries.V1.ServiceOrder;
using OsService.Domain.Entities;
using OsService.Domain.Repository.Interfaces.ServiceOrder;

namespace OsService.Application.Handers.V1.ServiceOrder;

public sealed class GetServiceOrderByIdHandler(IServiceOrderRepository repository) : IRequestHandler<GetServiceOrderByIdQuery, ServiceOrderEntity?>
{
    public async Task<ServiceOrderEntity?> Handle(GetServiceOrderByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            throw new ArgumentException("Id is required.", nameof(request));

        return await repository.GetServiceOrderByIdAsync(request.Id, cancellationToken);
    }
}