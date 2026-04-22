using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Entities;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.FeeType;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.FeeType
{
    public partial interface IFeeTypeService
    {
        Task<Response<FeeTypeDto>> InsertAsync(FeeTypeDto request);
        Task<Response<bool>> DeleteAsync(FeeTypeDto request);
        Task<Response<bool>> UpdateAsync(int id, FeeTypeDto request);
        Task<Response<List<FeeTypeDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<FeeTypeDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool feeTypeIsActive, int? page, int? size);
        Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string feeTypeCode);
        Task<Response<int>> DeactivateAsync(int feeTypeId, DeactivateRequestDto updateRequest);
    }
}