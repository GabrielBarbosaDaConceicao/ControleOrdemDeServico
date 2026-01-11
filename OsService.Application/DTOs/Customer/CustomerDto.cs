using System.ComponentModel.DataAnnotations;

namespace OsService.Application.DTOs.Customer
{
    public sealed class CustomerDto
    {
        [Key]
        public Guid Id { get; init; }

        [Required(ErrorMessage = "The Name fild is Required")]
        [MinLength(2, ErrorMessage = "The Name must have at least 2 characters")]
        [MaxLength(150, ErrorMessage = "The Name must have a maximum of 150 characters")]
        public string Name { get; init; } = default!;

        [StringLength(30, ErrorMessage = "The Phone must have a maximum of 30 characters")]
        public string? Phone { get; init; }

        [StringLength(30, ErrorMessage = "The Phone must have a maximum of 30 characters")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? Email { get; init; }

        [StringLength(30, ErrorMessage = "The Document must have a maximum of 30 characters")]
        [DataType(DataType.EmailAddress)]
        public string? Document { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}