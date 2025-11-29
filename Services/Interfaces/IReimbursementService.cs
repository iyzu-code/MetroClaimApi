using System;
using MetroClaim.Api.Dtos.Reimbursement;

namespace MetroClaim.Api.Services.Interfaces;

public interface IReimbursementService
{
    Task<IEnumerable<ReimbursementResponseDto>> GetByUserAsync(Guid userId, CancellationToken cancellationToken);
    
    Task<ReimbursementDetailDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task CreateAsync(ReimbursementRequestDto requestDto, CancellationToken cancellationToken);
}
