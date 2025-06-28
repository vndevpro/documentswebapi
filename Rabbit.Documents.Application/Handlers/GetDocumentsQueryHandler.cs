using GdNetDDD.Common;
using MediatR;
using Rabbit.Documents.Application.Queries;
using Rabbit.Documents.Application.ViewModels;
using Rabbit.Documents.Domain.Repositories;

namespace Rabbit.Documents.Application.Handlers
{
    public class GetDocumentsQueryHandler(IDocumentRepository documentRepository) : IRequestHandler<GetDocumentsQuery, PaginatedResult<DocumentViewModel>>
    {
        public async Task<PaginatedResult<DocumentViewModel>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
        {
            var result = await documentRepository.GetListAsync(request.InputModel.PageNumber, request.InputModel.PageSize);

            var documents = result.Items.Select(x => x.MapToViewModel()).ToList();

            return PaginatedResult<DocumentViewModel>.Create(documents, result.TotalCount, result.PageNumber, result.PageSize);
        }
    }
}
