using OsService.Domain.Entities;
using OsService.Application.Commands.V1.CreateCustomer;
using MediatR;
using OsService.Domain.Repository.Interfaces.Customer;

namespace OsService.Application.Handlers.V1.Customer;

public sealed class CreateCustomerHandler(ICustomerRepository customerRepository) : IRequestHandler<CreateCustomerCommand, Guid>
{
    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Name is required.");

            var customer = new CustomerEntity
            {
                Id = Guid.NewGuid(),
                Name = request.Name.Trim(),
                Phone = request.Phone?.Trim(),
                Email = request.Email?.Trim(),
                Document = request.Document?.Trim(),
                CreatedAt = DateTime.UtcNow
            };

            await customerRepository.InsertAsync(customer, cancellationToken);
            return customer.Id;
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException("Error creating customer.", ex.Message);
        }
    }
}