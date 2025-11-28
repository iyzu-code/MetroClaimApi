using MetroClaim.Api.Dtos.Category;
using MetroClaim.Api.Models;
using MetroClaim.Api.Repositrories.Interfaces;
using MetroClaim.Api.Services.Interfaces;
using Shiftly.Api.Repositories;

namespace MetroClaim.Api.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(CategoryRequestDto requestDto, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = requestDto.Name
        };

        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _categoryRepository.CreateAsync(category, cancellationToken);
        }, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(id, cancellationToken);
        if (category == null)
        {
            throw new NullReferenceException("User not found");
        }

        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _categoryRepository.DeleteAsync(category);
        }, cancellationToken);
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync(cancellationToken);
        if (!categories.Any())
        {
            throw new NullReferenceException("Category not found");
        }

        var categoryMap = categories.Select(c => new CategoryResponseDto(
            c.Id,
            c.Name!
        ));

        return categoryMap;
    }

    public async Task<CategoryResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(id, cancellationToken);
        if (category == null)
        {
            throw new NullReferenceException("Category not found");
        }

        var categoryMap = new CategoryResponseDto(
            category.Id,
            category.Name!
        );

        return categoryMap;
    }

    public async Task UpdateAsync(Guid id, CategoryRequestDto requestDto, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(id, cancellationToken);
        if (category is null)
        {
            throw new NullReferenceException("Category not found");
        }

        category.Name = requestDto.Name;
        category.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.CommitTransactionAsync(async () =>
        {
            await _categoryRepository.UpdateAsync(category);
        }, cancellationToken);
    }
}
