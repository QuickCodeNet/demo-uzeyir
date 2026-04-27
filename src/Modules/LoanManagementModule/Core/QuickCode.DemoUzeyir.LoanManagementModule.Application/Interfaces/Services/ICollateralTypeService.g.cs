using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.CollateralType;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.CollateralType
{
    public partial interface ICollateralTypeService
    {
        Task<Response<CollateralTypeDto>> InsertAsync(CollateralTypeDto request);
        Task<Response<bool>> DeleteAsync(CollateralTypeDto request);
        Task<Response<bool>> UpdateAsync(int id, CollateralTypeDto request);
        Task<Response<List<CollateralTypeDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CollateralTypeDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool collateralTypeIsActive, int? page, int? size);
        Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string collateralTypeCode);
        Task<Response<int>> DeactivateAsync(int collateralTypeId, DeactivateRequestDto updateRequest);
    }
}