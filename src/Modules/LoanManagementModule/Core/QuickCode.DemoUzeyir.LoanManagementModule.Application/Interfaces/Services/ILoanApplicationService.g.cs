using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.LoanApplication;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.LoanApplication
{
    public partial interface ILoanApplicationService
    {
        Task<Response<LoanApplicationDto>> InsertAsync(LoanApplicationDto request);
        Task<Response<bool>> DeleteAsync(LoanApplicationDto request);
        Task<Response<bool>> UpdateAsync(int id, LoanApplicationDto request);
        Task<Response<List<LoanApplicationDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<LoanApplicationDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<GetByApplicationNumberResponseDto>> GetByApplicationNumberAsync(Guid loanApplicationApplicationNumber);
        Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int loanApplicationCustomerId, int? page, int? size);
        Task<Response<List<GetPendingReviewResponseDto>>> GetPendingReviewAsync(LoanApplicationStatus loanApplicationStatus, int? page, int? size);
        Task<Response<List<GetApplicationsWithProductResponseDto>>> GetApplicationsWithProductAsync(int loanApplicationsCustomerId, int loanApplicationsLoanProductId, int loanProductsId, int? page, int? size);
        Task<Response<int>> SubmitApplicationAsync(int loanApplicationId, SubmitApplicationRequestDto updateRequest);
        Task<Response<int>> ApproveApplicationAsync(int loanApplicationId, ApproveApplicationRequestDto updateRequest);
        Task<Response<int>> RejectApplicationAsync(int loanApplicationId, RejectApplicationRequestDto updateRequest);
        Task<Response<int>> WithdrawApplicationAsync(int loanApplicationId, WithdrawApplicationRequestDto updateRequest);
    }
}