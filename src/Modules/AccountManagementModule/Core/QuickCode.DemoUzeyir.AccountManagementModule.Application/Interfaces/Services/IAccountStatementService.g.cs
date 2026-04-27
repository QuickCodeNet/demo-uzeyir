using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.AccountStatement;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.AccountStatement
{
    public partial interface IAccountStatementService
    {
        Task<Response<AccountStatementDto>> InsertAsync(AccountStatementDto request);
        Task<Response<bool>> DeleteAsync(AccountStatementDto request);
        Task<Response<bool>> UpdateAsync(int id, AccountStatementDto request);
        Task<Response<List<AccountStatementDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AccountStatementDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByAccountIdResponseDto>>> GetByAccountIdAsync(int accountStatementAccountId, int? page, int? size);
        Task<Response<List<GetByDateRangeResponseDto>>> GetByDateRangeAsync(int accountStatementAccountId, DateTime accountStatementGeneratedDateFrom, DateTime accountStatementGeneratedDateTo, int? page, int? size);
        Task<Response<int>> DeleteStatementAsync(int accountStatementId);
    }
}