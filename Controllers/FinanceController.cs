using MetroClaim.Api.Dtos.Finance;
using MetroClaim.Api.Services.Interfaces;
using MetroClaim.Api.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetroClaim.Api.Controllers;

[Route("api/finance")]
[ApiController]
[Authorize(Roles = "finance")]
public class FinanceController : ControllerBase
{
    private readonly IFinanceService _financeService;

    public FinanceController(IFinanceService financeService)
    {
        _financeService = financeService;
    }

    // GET: api/finance/pending-approval
    [HttpGet("pending-approval")]
    public async Task<ActionResult<IEnumerable<FinanceTaskDto>>> GetPendingApproval(CancellationToken cancellationToken)
    {
        var results = await _financeService.GetPendingApprovalsAsync(cancellationToken);
        return Ok(new ApiResponse<IEnumerable<FinanceTaskDto>>(results));
    }

    // GET: api/finance/pending-payment
    [HttpGet("pending-payment")]
    public async Task<ActionResult<IEnumerable<FinanceTaskDto>>> GetPendingPayment(CancellationToken cancellationToken)
    {
        var results = await _financeService.GetPendingPaymentsAsync(cancellationToken);
        return Ok(new ApiResponse<IEnumerable<FinanceTaskDto>>(results));
    }

    // POST: api/finance/approve
    [HttpPost("approve")]
    public async Task<IActionResult> Approve([FromBody] FinanceApprovalRequestDto request, CancellationToken cancellationToken)
    {
        await _financeService.ApproveAsync(request, cancellationToken);
        return Ok(new ApiResponse<object>("reimbursement approved by finance"));
    }

    // POST: api/finance/reject
    [HttpPost("reject")]
    public async Task<IActionResult> Reject([FromBody] FinanceApprovalRequestDto request, CancellationToken cancellationToken)
    {

        await _financeService.RejectAsync(request, cancellationToken);
        return Ok(new ApiResponse<object>("reimbursement rejected by finance"));
    }

    // POST: api/finance/pay
    [HttpPost("pay")]
    public async Task<IActionResult> Pay([FromBody] PaymentExecutionDto request, CancellationToken cancellationToken)
    {
        await _financeService.PayAsync(request, cancellationToken);
        return Ok(new ApiResponse<object>("reimbursement paid"));
    }
}