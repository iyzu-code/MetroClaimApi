using MetroClaim.Api.Dtos.Category;
using MetroClaim.Api.Services.Interfaces;
using MetroClaim.Api.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetroClaim.Api.Controllers;

[ApiController]
[Route("api/category")]
[Authorize(Roles = "admin")]

public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryRequestDto requestDto, CancellationToken cancellationToken)
    {
        await _categoryService.CreateAsync(requestDto,cancellationToken);
        return Ok(new ApiResponse<object>("category created"));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategory(CancellationToken cancellationToken)
    {
        var categories = await _categoryService.GetAllAsync(cancellationToken);
        return Ok(new ApiResponse<IEnumerable<CategoryResponseDto>>(categories));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id, CancellationToken cancellationToken)
    {
        var category = await _categoryService.GetByIdAsync(id, cancellationToken);
        return Ok(new ApiResponse<CategoryResponseDto>(category));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(Guid id, CancellationToken cancellationToken)
    {
        await _categoryService.DeleteAsync(id, cancellationToken);
        return Ok(new ApiResponse<object>("category deleted"));
    }

    [HttpPut]
    public async Task<IActionResult> EditCategory(Guid id, CategoryRequestDto requestDto, CancellationToken cancellationToken)
    {
        await _categoryService.UpdateAsync(id, requestDto, cancellationToken);
        return Ok(new ApiResponse<object>("category updated"));
    }
}
