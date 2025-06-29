using GdNetValidations;
using System.ComponentModel.DataAnnotations;

namespace Rabbit.Documents.Application.Queries
{
    public sealed class SearchQueryModel : PaginationQueryModel
    {
        [Required]
        [Length(2, 1000)]
        public required string SearchText { get; set; }
    }
}
