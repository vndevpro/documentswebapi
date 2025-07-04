using GdNetValidations.CustomAttributes;
using System.ComponentModel;

namespace Rabbit.Documents.Application.InputModels
{
    [AtLeastOneRequired(nameof(TitleTerms), nameof(DescriptionTerms))]
    public sealed class AdvancedSearchQueryModel : PaginationQueryModel
    {
        [Description("Terms to search in document title.")]
        public string? TitleTerms { get; set; }

        [Description("Terms to search in document description.")]
        public string? DescriptionTerms { get; set; }
    }
}
