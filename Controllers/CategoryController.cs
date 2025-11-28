using MetroClaim.Api.Dtos.Category;
using MetroClaim.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MetroClaim.Api.Controllers;

[ApiController]
[Route("api/category")]

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
        return Ok("Category created");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategory(CancellationToken cancellationToken)
    {
        var categories = await _categoryService.GetAllAsync(cancellationToken);
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id, CancellationToken cancellationToken)
    {
        var category = await _categoryService.GetByIdAsync(id, cancellationToken);
        return Ok(category);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(Guid id, CancellationToken cancellationToken)
    {
        await _categoryService.DeleteAsync(id, cancellationToken);
        return Ok("Category Deleted");
    }

    [HttpPut]
    public async Task<IActionResult> EditCategory(Guid id, CategoryRequestDto requestDto, CancellationToken cancellationToken)
    {
        await _categoryService.UpdateAsync(id, requestDto, cancellationToken);
        return Ok("Category updated");
    }
}
