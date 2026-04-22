using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.LoanPayment;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.LoanPayment
{
    public partial interface ILoanPaymentService
    {
        Task<Response<LoanPaymentDto>> InsertAsync(LoanPaymentDto request);
        Task<Response<bool>> DeleteAsync(LoanPaymentDto request);
        Task<Response<bool>> UpdateAsync(int id, LoanPaymentDto request);
        Task<Response<List<LoanPaymentDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<LoanPaymentDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByLoanIdResponseDto>>> GetByLoanIdAsync(int loanPaymentLoanId, int? page, int? size);
        Task<Response<List<GetByDateRangeResponseDto>>> GetByDateRangeAsync(int loanPaymentLoanId, DateTime loanPaymentPaymentDateFrom, DateTime loanPaymentPaymentDateTo, int? page, int? size);
        Task<Response<long>> GetTotalPaymentsForLoanAsync(int loanPaymentLoanId);
    }
}