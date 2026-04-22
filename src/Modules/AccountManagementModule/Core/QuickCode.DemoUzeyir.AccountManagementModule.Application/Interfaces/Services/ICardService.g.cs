using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.AccountManagementModule.Application.Dtos.Card;
using QuickCode.DemoUzeyir.AccountManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.AccountManagementModule.Application.Services.Card
{
    public partial interface ICardService
    {
        Task<Response<CardDto>> InsertAsync(CardDto request);
        Task<Response<bool>> DeleteAsync(CardDto request);
        Task<Response<bool>> UpdateAsync(int id, CardDto request);
        Task<Response<List<CardDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CardDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByAccountIdResponseDto>>> GetByAccountIdAsync(int cardAccountId, int? page, int? size);
        Task<Response<List<GetCardsWithTypeResponseDto>>> GetCardsWithTypeAsync(int cardTypesId, int cardsAccountId, int cardsCardTypeId, int? page, int? size);
        Task<Response<List<GetExpiredCardsResponseDto>>> GetExpiredCardsAsync(CardStatus cardStatus, int? page, int? size);
        Task<Response<int>> ActivateCardAsync(int cardId, ActivateCardRequestDto updateRequest);
        Task<Response<int>> BlockCardAsync(int cardId, BlockCardRequestDto updateRequest);
        Task<Response<int>> ReportLostOrStolenAsync(int cardId, ReportLostOrStolenRequestDto updateRequest);
    }
}