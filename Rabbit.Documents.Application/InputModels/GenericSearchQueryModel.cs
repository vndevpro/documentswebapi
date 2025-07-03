using System.ComponentModel.DataAnnotations;

namespace Rabbit.Documents.Application.InputModels
{
    public sealed class GenericSearchQueryModel : PaginationQueryModel
    {
        [Required]
        [Length(2, 1000)]
        public required string SearchText { get; set; }
    }
}
