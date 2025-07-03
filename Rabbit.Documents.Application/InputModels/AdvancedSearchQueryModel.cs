using GdNetValidations.CustomAttributes;

namespace Rabbit.Documents.Application.InputModels
{
    [AtLeastOneRequired(nameof(TitleSearchText), nameof(DescriptionSearchText))]
    public sealed class AdvancedSearchQueryModel : PaginationQueryModel
    {
        public string? TitleSearchText { get; set; }

        public string? DescriptionSearchText { get; set; }
    }
}
