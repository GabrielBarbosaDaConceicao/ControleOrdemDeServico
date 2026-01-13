using OsService.Domain.Entities;
using OsService.Domain.Enums;
using MediatR;
using OsService.Domain.Repository.Interfaces.Customer;

namespace OsService.Application.Commands.V1.ServiceOrder;

public sealed class OpenServiceOrderHandler(ICustomerRepository customers) : IRequestHandler<OpenServiceOrderCommand, (Guid Id, int Number)>
{
    public async Task<(Guid Id, int Number)> Handle(OpenServiceOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.CustomerId == Guid.Empty)
                throw new ArgumentException("CustomerId is required.");

            if (string.IsNullOrWhiteSpace(request.Description) || request.Description.Length > 500)
                throw new ArgumentException("Description is required and must be <= 500 chars.");

            var customerExist = await customers.ExistsAsync(request.CustomerId, cancellationToken);
            if (!customerExist)
                throw new KeyNotFoundException("Customer not found.");

            var serviceOrderEntity = new ServiceOrderEntity
            {
                Id = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                Description = request.Description.Trim(),
                Status = ServiceOrderStatus.Open,
                OpenedAt = DateTime.UtcNow
            };

            return await customers.InsertAndReturnNumberAsync(serviceOrderEntity, cancellationToken);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Error in OpenServiceOrderHandler | {ex.Message}");
        }
    }
}