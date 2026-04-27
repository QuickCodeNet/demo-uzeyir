using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.AccountType;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.AccountType
{
    public partial interface IAccountTypeService
    {
        Task<Response<AccountTypeDto>> InsertAsync(AccountTypeDto request);
        Task<Response<bool>> DeleteAsync(AccountTypeDto request);
        Task<Response<bool>> UpdateAsync(int id, AccountTypeDto request);
        Task<Response<List<AccountTypeDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AccountTypeDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool accountTypeIsActive, int? page, int? size);
        Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string accountTypeCode);
        Task<Response<int>> UpdateInterestRateAsync(int accountTypeId, UpdateInterestRateRequestDto updateRequest);
        Task<Response<int>> DeactivateAsync(int accountTypeId, DeactivateRequestDto updateRequest);
    }
}