using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OsService.Application.DTOs
{
    public sealed class CustomerDto
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; init; }

        [Required(ErrorMessage = "The Name fild is Required")]
        [MinLength(2, ErrorMessage = "The Name must have at least 2 characters")]
        [MaxLength(150, ErrorMessage = "The Name must have a maximum of 150 characters")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "The name cannot contain only spaces")]
        public string Name { get; init; } = default!;

        [StringLength(30, ErrorMessage = "The Phone must have a maximum of 30 characters")]
        public string? Phone { get; init; }

        [StringLength(30, ErrorMessage = "The Phone must have a maximum of 30 characters")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? Email { get; init; }

        [StringLength(30, ErrorMessage = "The Document must have a maximum of 30 characters")]
        public string? Document { get; init; }

        [JsonIgnore]
        public DateTime CreatedAt { get; init; }
    }
}