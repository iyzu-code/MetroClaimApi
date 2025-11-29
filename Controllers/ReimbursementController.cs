using MetroClaim.Api.Dtos.Reimbursement;
using MetroClaim.Api.Services.Interfaces;
using MetroClaim.Api.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MetroClaim.Api.Controllers;

[Route("api/reimbursements")]
[ApiController]
public class ReimbursementController : ControllerBase
{
    private readonly IReimbursementService _reimbursementService;

    public ReimbursementController(IReimbursementService reimbursementService)
    {
        _reimbursementService = reimbursementService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReimbursement([FromBody] ReimbursementRequestDto requestDto, CancellationToken cancellationToken)
    {

        await _reimbursementService.CreateAsync(requestDto, cancellationToken);

        return Ok(new ApiResponse<object>("reimbursement created"));
    }

    [HttpGet("me")]
    public async Task<ActionResult<IEnumerable<ReimbursementResponseDto>>> GetMyReimbursementHistory([FromQuery] Guid userId, CancellationToken cancellationToken)
    {
        var result = await _reimbursementService.GetByUserAsync(userId, cancellationToken);
        return Ok(new ApiResponse<IEnumerable<ReimbursementResponseDto>>(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReimbursementDetailDto>> GetDetail(Guid id, CancellationToken cancellationToken)
    {
        var result = await _reimbursementService.GetByIdAsync(id, cancellationToken);
        return Ok(new ApiResponse<ReimbursementDetailDto>(result));
    }
}