using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.CardType;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.CardType
{
    public partial interface ICardTypeService
    {
        Task<Response<CardTypeDto>> InsertAsync(CardTypeDto request);
        Task<Response<bool>> DeleteAsync(CardTypeDto request);
        Task<Response<bool>> UpdateAsync(int id, CardTypeDto request);
        Task<Response<List<CardTypeDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CardTypeDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool cardTypeIsActive, int? page, int? size);
        Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string cardTypeCode);
        Task<Response<int>> DeactivateAsync(int cardTypeId, DeactivateRequestDto updateRequest);
    }
}