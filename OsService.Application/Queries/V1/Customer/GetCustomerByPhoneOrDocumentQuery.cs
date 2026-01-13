using MediatR;
using OsService.Application.DTOs;

namespace OsService.Application.Queries.V1.Customer;

public sealed record GetCustomerByPhoneOrDocumentQuery(string? Phone, string? Document) : IRequest<CustomerDto?>;