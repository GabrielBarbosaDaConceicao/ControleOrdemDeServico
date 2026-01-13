using MediatR;
using OsService.Application.DTOs;
using OsService.Application.Queries.V1.Customer;
using OsService.Domain.Repository.Interfaces.Customer;

namespace OsService.Application.Handers.V1.Customer;

public sealed class GetCustomerByIdHandler(ICustomerRepository customers) : IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
{
    public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
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