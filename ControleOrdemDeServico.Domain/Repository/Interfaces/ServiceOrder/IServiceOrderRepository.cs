using OsService.Domain.Entities;

namespace OsService.Domain.Repository.Interfaces.ServiceOrder;

public interface IServiceOrderRepository
{
    Task<ServiceOrderEntity?> GetServiceOrderByIdAsync(Guid id, CancellationToken ct);
    Task<IEnumerable<ServiceOrderEntity>> GetServiceOrdersByCustomerId(Guid customerId, CancellationToken ct);  
}