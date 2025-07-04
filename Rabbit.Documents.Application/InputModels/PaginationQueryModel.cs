using GdNetValidations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rabbit.Documents.Application.InputModels
{
    /// <summary>
    /// For APIs that support pagination. Example when using in minimal api MapGet: [AsParameters] PaginationInputModel model
    /// </summary>
    public class PaginationQueryModel : IValidationRequired
    {
        [Range(0, int.MaxValue)]
        [Description("Page number, starting from 0 - default is 0")]
        public int? PageNumber { get; set; }

        [Range(1, 1000)]
        [Description("Page size, starting from 1 - default is 10")]
        public int? PageSize { get; set; }
    }
}
