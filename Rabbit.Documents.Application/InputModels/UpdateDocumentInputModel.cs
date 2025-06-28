using GdNetValidations;
using System.ComponentModel.DataAnnotations;

namespace Rabbit.Documents.Application.InputModels
{
    public class UpdateDocumentInputModel : IValidationRequired
    {
        [Required]
        [StringLength(128, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
