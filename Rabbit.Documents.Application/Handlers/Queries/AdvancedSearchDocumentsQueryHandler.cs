using MediatR;
using Rabbit.Documents.Application.InputModels;
using Rabbit.Documents.Application.Queries;
using Rabbit.Documents.Application.ViewModels;
using Rabbit.Documents.Domain.Repositories;

namespace Rabbit.Documents.Application.Handlers.Queries
{
    public class AdvancedSearchDocumentsQueryHandler(IDocumentRepository documentRepository) : IRequestHandler<AdvancedSearchDocumentsQuery, PaginatedResult<DocumentViewModel>>
    {
        public async Task<PaginatedResult<DocumentViewModel>> Handle(AdvancedSearchDocumentsQuery request, CancellationToken cancellationToken)
        {
            var searchableFields = MapToSearchableFields(request.InputModel);

            var result = await documentRepository.SearchAsync(searchableFields, request.InputModel.PageNumber, request.InputModel.PageSize);
            var documents = result.Items.Select(x => x.MapToViewModel()).ToList();

            return PaginatedResult.Create(documents, result.TotalCount, result.PageNumber, result.PageSize);
        }

        private IDictionary<DocumentSearchableField, string> MapToSearchableFields(AdvancedSearchQueryModel searchQueryModel)
        {
            var searchableFields = new Dictionary<DocumentSearchableField, string>();

            if (!string.IsNullOrWhiteSpace(searchQueryModel.TitleSearchText))
            {
                searchableFields.Add(DocumentSearchableField.Title, searchQueryModel.TitleSearchText);
            }

            if (!string.IsNullOrWhiteSpace(searchQueryModel.DescriptionSearchText))
            {
                searchableFields.Add(DocumentSearchableField.Description, searchQueryModel.DescriptionSearchText);
            }

            return searchableFields;
        }
    }
}
