using MediatR;
using OsService.Application.DTOs.Customer;
using OsService.Application.Queries.V1.Customer;
using OsService.Infrastructure.Repository;

namespace OsService.Application.Handers.Customer;

public sealed class GetCustomerByIdHandler(ICustomerRepository customers) : IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
{
    public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            throw new ArgumentException("Id is required.", nameof(request));

        var entity = await customers.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null)
            return null;

        return new CustomerDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Phone = entity.Phone,
            Email = entity.Email,
            Document = entity.Document,
            CreatedAt = entity.CreatedAt
        };
    }
}