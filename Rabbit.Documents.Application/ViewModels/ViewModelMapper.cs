using Rabbit.Documents.Domain.Entities;

namespace Rabbit.Documents.Application.ViewModels
{
    internal static class ViewModelMapper
    {
        public static DocumentViewModel MapToViewModel(this Document document)
        {
            return new DocumentViewModel
            {
                Id = document.Id,
                Title = document.Title,
                Description = document.Description,
                CreatedAt = document.CreatedAt,
                UpdatedAt = document.UpdatedAt,
            };
        }
    }
}
