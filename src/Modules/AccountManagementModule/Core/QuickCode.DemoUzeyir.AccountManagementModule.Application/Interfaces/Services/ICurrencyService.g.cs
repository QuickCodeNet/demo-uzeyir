using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.Currency;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.Currency
{
    public partial interface ICurrencyService
    {
        Task<Response<CurrencyDto>> InsertAsync(CurrencyDto request);
        Task<Response<bool>> DeleteAsync(CurrencyDto request);
        Task<Response<bool>> UpdateAsync(int id, CurrencyDto request);
        Task<Response<List<CurrencyDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CurrencyDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool currencyIsActive, int? page, int? size);
        Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string currencyCode);
        Task<Response<int>> DeactivateAsync(string currencyCode, DeactivateRequestDto updateRequest);
    }
}