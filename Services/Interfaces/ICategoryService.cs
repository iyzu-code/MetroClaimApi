using MetroClaim.Api.Dtos.Category;

namespace MetroClaim.Api.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponseDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<CategoryResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(CategoryRequestDto requestDto, CancellationToken cancellationToken);
    Task UpdateAsync(Guid id, CategoryRequestDto requestDto, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}