using OsService.Domain.Entities;
using OsService.Domain.Enums;
using OsService.Infrastructure.Databases;
using Dapper;
using OsService.Domain.Repository.Interfaces.ServiceOrder;

namespace OsService.Infrastructure.Repository;

public sealed class ServiceOrderRepository(IDefaultSqlConnectionFactory factory) : IServiceOrderRepository
{
    public async Task<ServiceOrderEntity?> GetServiceOrderByIdAsync(Guid id, CancellationToken ct)
    {
        const string sql = @"
                            SELECT Id, Number, CustomerId, Description,
                                   Status = CAST(Status AS INT),
                                   OpenedAt
                            FROM dbo.ServiceOrders
                            WHERE Id = @Id;";

        using var conn = factory.Create();
        var raw = await conn.QuerySingleOrDefaultAsync<dynamic>(
            new CommandDefinition(sql, new { Id = id }, cancellationToken: ct));

        if (raw is null) return null;

        return new ServiceOrderEntity
        {
            Id = raw.Id,
            Number = raw.Number,
            CustomerId = raw.CustomerId,
            Description = raw.Description,
            Status = (ServiceOrderStatus)(int)raw.Status,
            OpenedAt = raw.OpenedAt
        };
    }

    public async Task<IEnumerable<ServiceOrderEntity>> GetServiceOrdersByCustomerId(Guid customerId, CancellationToken ct)
    {
        const string sql = @"
                        SELECT Id, Number, CustomerId, Description,
                               Status = CAST(Status AS INT),
                               OpenedAt
                        FROM dbo.ServiceOrders
                        WHERE CustomerId = @CustomerId;";

        using var conn = factory.Create();
        var raws = await conn.QueryAsync<dynamic>(
            new CommandDefinition(sql, new { CustomerId = customerId }, cancellationToken: ct));

        var result = new List<ServiceOrderEntity>();
        foreach (var raw in raws)
        {
            result.Add(new ServiceOrderEntity
            {
                Id = raw.Id,
                Number = raw.Number,
                CustomerId = raw.CustomerId,
                Description = raw.Description,
                Status = (ServiceOrderStatus)(int)raw.Status,
                OpenedAt = raw.OpenedAt
            });
        }

        return result;
    }
}