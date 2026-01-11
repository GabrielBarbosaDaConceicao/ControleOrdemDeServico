using OsService.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OsService.Application.DTOs.Customer
{
    public sealed class ServiceOrderDto
    {
        [Key]
        public Guid Id { get; init; }

        [DisplayName("Number")]
        public int Number { get; init; }

        [Required(ErrorMessage = "The Customer Id is required")]
        [DisplayName("Customer Id")]
        public Guid CustomerId { get; init; }

        [Required(ErrorMessage = "The Description is required")]
        [StringLength(500, ErrorMessage = "The description has a maximum size of 500 characters"), MinLength(1, ErrorMessage = "The Description must have at least 1 characters")]
        public string Description { get; init; } = default!;

        [DisplayName("Order Service Status")]
        public ServiceOrderStatus Status { get; init; } = ServiceOrderStatus.Open;
        public DateTime OpenedAt { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal? Price { get; init; }

        [DisplayName("Coin")]
        public string? Coin { get; init; } = "BRL";//"USD", "EUR", "BRL", etc.

        [DisplayName("Updated Date")]
        public DateTime? UpdatedPriceAt { get; init; }
    }
}