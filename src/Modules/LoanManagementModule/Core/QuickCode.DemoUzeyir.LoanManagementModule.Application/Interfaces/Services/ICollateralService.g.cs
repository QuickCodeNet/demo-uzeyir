using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.Collateral;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.Collateral
{
    public partial interface ICollateralService
    {
        Task<Response<CollateralDto>> InsertAsync(CollateralDto request);
        Task<Response<bool>> DeleteAsync(CollateralDto request);
        Task<Response<bool>> UpdateAsync(int id, CollateralDto request);
        Task<Response<List<CollateralDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CollateralDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByApplicationIdResponseDto>>> GetByApplicationIdAsync(int collateralLoanApplicationId, int? page, int? size);
        Task<Response<List<GetCollateralsWithTypeResponseDto>>> GetCollateralsWithTypeAsync(int collateralsLoanApplicationId, int collateralsCollateralTypeId, int collateralTypesId, int? page, int? size);
        Task<Response<int>> UpdateMarketValueAsync(int collateralId, UpdateMarketValueRequestDto updateRequest);
    }
}