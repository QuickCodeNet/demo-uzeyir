using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.LoanProduct;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.LoanProduct
{
    public partial interface ILoanProductService
    {
        Task<Response<LoanProductDto>> InsertAsync(LoanProductDto request);
        Task<Response<bool>> DeleteAsync(LoanProductDto request);
        Task<Response<bool>> UpdateAsync(int id, LoanProductDto request);
        Task<Response<List<LoanProductDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<LoanProductDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool loanProductIsActive, int? page, int? size);
        Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string loanProductCode);
        Task<Response<int>> UpdateInterestRateAsync(int loanProductId, UpdateInterestRateRequestDto updateRequest);
        Task<Response<int>> DeactivateAsync(int loanProductId, DeactivateRequestDto updateRequest);
    }
}