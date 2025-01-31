using Inbursa.Application.Contracts;
using Inbursa.Application.Models;
using Inbursa.Domain.Dtos.Requests;
using Inbursa.Domain.Dtos.Responses;
using Inbursa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inbursa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanApplicationService _loanApplicationService;

        public LoanController(ILoanApplicationService loanApplicationService)
        {
            _loanApplicationService = loanApplicationService;
        }

        [HttpPost("simulate")]
        public async Task<IActionResult> SimulateLoan([FromBody] ProposalRequestDto request)
        {
            var (isValid, errors, result) = await _loanApplicationService.SimulateLoanAsync(request);

            if (!isValid)
                return BadRequest(ResponseModel<PaymentFlowSummaryResponseDto>.Error(400, errors));

            return Ok(ResponseModel<PaymentFlowSummaryResponseDto>.Success(result));
        }
    }
}
