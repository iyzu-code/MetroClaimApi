using MetroClaim.Api.Dtos.Approval;
using MetroClaim.Api.Services.Interfaces;
using MetroClaim.Api.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetroClaim.Api.Controllers;

[Route("api/approvals")]
[ApiController]
[Authorize(Roles = "manager")]
public class ApprovalController : ControllerBase
{
    private readonly IApprovalService _approvalService;

    public ApprovalController(IApprovalService approvalService)
    {
        _approvalService = approvalService;
    }

    // GET: api/approvals/manager/pending?managerId=...
    [HttpGet("manager/pending")]
    public async Task<ActionResult<IEnumerable<PendingApprovalDto>>> GetManagerPending([FromQuery] Guid managerId, CancellationToken cancellationToken)
    {
        var results = await _approvalService.GetPendingManagerApprovalsAsync(managerId, cancellationToken);
        return Ok(new ApiResponse<IEnumerable<PendingApprovalDto>>(results));
    }

    // POST: api/approvals/manager/approve
    [HttpPost("manager/approve")]
    public async Task<IActionResult> ManagerApprove([FromBody] ApprovalRequestDto request, CancellationToken cancellationToken)
    {
        await _approvalService.ApproveByManagerAsync(request, cancellationToken);
        return Ok(new ApiResponse<object>("reimbursement approves by manager"));
    }

    // POST: api/approvals/manager/reject
    [HttpPost("manager/reject")]
    public async Task<IActionResult> ManagerReject([FromBody] ApprovalRequestDto request, CancellationToken cancellationToken)
    {

        await _approvalService.RejectByManagerAsync(request, cancellationToken);
        return Ok(new ApiResponse<object>("reimbursement rejected by manager"));
    }
}