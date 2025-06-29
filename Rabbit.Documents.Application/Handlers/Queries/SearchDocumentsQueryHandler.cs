using MediatR;
using Rabbit.Documents.Application.Queries;
using Rabbit.Documents.Application.ViewModels;
using Rabbit.Documents.Domain.Repositories;

namespace Rabbit.Documents.Application.Handlers.Queries
{
    public class SearchDocumentsQueryHandler(IDocumentRepository documentRepository) : IRequestHandler<SearchDocumentsQuery, PaginatedResult<DocumentViewModel>>
    {
        public async Task<PaginatedResult<DocumentViewModel>> Handle(SearchDocumentsQuery request, CancellationToken cancellationToken)
        {
            var searchTerms = request.InputModel.SearchText.ConvertToFullTextSearchTerms();

            var result = await documentRepository.Search(searchTerms, request.InputModel.PageNumber, request.InputModel.PageSize);
            var documents = result.Items.Select(x => x.MapToViewModel()).ToList();

            return PaginatedResult.Create(documents, result.TotalCount, result.PageNumber, result.PageSize);
        }
    }
}
