using GdNetValidations;
using System.ComponentModel.DataAnnotations;

namespace Rabbit.Documents.Application.InputModels
{
    /// <summary>
    /// For APIs that support pagination. Example when using in minimal api MapGet: [AsParameters] PaginationInputModel model
    /// </summary>
    public class PaginationQueryModel : IValidationRequired
    {
        [Range(0, int.MaxValue)]
        public int? PageNumber { get; set; }

        [Range(1, 1000)]
        public int? PageSize { get; set; }
    }
}
