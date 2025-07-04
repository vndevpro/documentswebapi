using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rabbit.Documents.Application.InputModels
{
    public sealed class GenericSearchQueryModel : PaginationQueryModel
    {
        [Required]
        [Length(2, 1000)]
        [Description("Text to search in all possible fields. Auto convert to full-text-search terms for more possible results.")]
        public required string SearchText { get; set; }
    }
}
