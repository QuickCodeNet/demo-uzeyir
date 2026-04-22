using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.Account;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.Account
{
    public partial interface IAccountService
    {
        Task<Response<AccountDto>> InsertAsync(AccountDto request);
        Task<Response<bool>> DeleteAsync(AccountDto request);
        Task<Response<bool>> UpdateAsync(int id, AccountDto request);
        Task<Response<List<AccountDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AccountDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<GetByAccountNumberResponseDto>> GetByAccountNumberAsync(string accountAccountNumber);
        Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int accountCustomerId, int? page, int? size);
        Task<Response<List<GetAccountsWithDetailsResponseDto>>> GetAccountsWithDetailsAsync(int accountsCustomerId, int accountAccountTypeId, int accountCurrencyId, int accountTypeId, int currencyId, int? page, int? size);
        Task<Response<List<GetLowBalanceAccountsResponseDto>>> GetLowBalanceAccountsAsync(AccountStatus accountStatus, int? page, int? size);
        Task<Response<List<GetDormantAccountsResponseDto>>> GetDormantAccountsAsync(AccountStatus accountStatus, int? page, int? size);
        Task<Response<long>> GetTotalBalanceByCustomerAsync(int accountCustomerId, AccountStatus accountStatus);
        Task<Response<int>> ApproveAccountAsync(int accountId, ApproveAccountRequestDto updateRequest);
        Task<Response<int>> FreezeAccountAsync(int accountId, FreezeAccountRequestDto updateRequest);
        Task<Response<int>> CloseAccountAsync(int accountId, CloseAccountRequestDto updateRequest);
        Task<Response<int>> UpdateBalanceAsync(int accountId, UpdateBalanceRequestDto updateRequest);
    }
}