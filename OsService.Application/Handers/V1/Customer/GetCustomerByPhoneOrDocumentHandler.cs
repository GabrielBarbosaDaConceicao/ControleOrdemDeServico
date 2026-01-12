using MediatR;
using OsService.Application.DTOs.Customer;
using OsService.Application.Queries.V1.Customer;
using OsService.Domain.Repository.Interfaces.Customer;

namespace OsService.Application.Handers.V1.Customer;

public sealed class GetCustomerByPhoneOrDocumentHandler(ICustomerRepository customers) : IRequestHandler<GetCustomerByPhoneOrDocumentQuery, CustomerDto?>
{
    public async Task<CustomerDto?> Handle(GetCustomerByPhoneOrDocumentQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Phone) && string.IsNullOrWhiteSpace(request.Document))
            throw new ArgumentException("At least phone or document must be provided.");

        var entity = await customers.GetByPhoneOrDocumentAsync(request.Phone, request.Document, cancellationToken);
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