using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.AccountHolder;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.AccountHolder
{
    public partial interface IAccountHolderService
    {
        Task<Response<AccountHolderDto>> InsertAsync(AccountHolderDto request);
        Task<Response<bool>> DeleteAsync(AccountHolderDto request);
        Task<Response<bool>> UpdateAsync(int accountId, int customerId, AccountHolderDto request);
        Task<Response<List<AccountHolderDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AccountHolderDto>> GetItemAsync(int accountId, int customerId);
        Task<Response<bool>> DeleteItemAsync(int accountId, int customerId);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetHoldersByAccountIdResponseDto>>> GetHoldersByAccountIdAsync(int accountHolderAccountId, int? page, int? size);
        Task<Response<List<GetAccountsByHolderIdResponseDto>>> GetAccountsByHolderIdAsync(int accountHolderCustomerId, int? page, int? size);
        Task<Response<int>> RemoveHolderAsync(int accountHolderAccountId, int accountHolderCustomerId);
    }
}