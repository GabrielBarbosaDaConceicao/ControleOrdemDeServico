using MediatR;

namespace OsService.Application.Commands.V1.CreateCustomer;

public sealed record CreateCustomerCommand(string Name, string? Phone, string? Email, string? Document) : IRequest<Guid>
{
    public static explicit operator CreateCustomerCommand(Domain.Entities.CustomerEntity customer)
    {
        return new CreateCustomerCommand(customer.Name, customer.Phone, customer.Email, customer.Document);
    }
}