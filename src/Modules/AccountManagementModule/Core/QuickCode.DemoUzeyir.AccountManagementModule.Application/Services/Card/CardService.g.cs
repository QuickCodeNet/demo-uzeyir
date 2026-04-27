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
    public partial class CardService : ICardService
    {
        private readonly ILogger<CardService> _logger;
        private readonly ICardRepository _repository;
        public CardService(ILogger<CardService> logger, ICardRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<CardDto>> InsertAsync(CardDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(CardDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, CardDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<CardDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<CardDto>> GetItemAsync(int id)
        {
            var returnValue = await _repository.GetByPkAsync(id);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteItemAsync(int id)
        {
            var deleteItem = await _repository.GetByPkAsync(id);
            if (deleteItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.DeleteAsync(deleteItem.Value);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> TotalItemCountAsync()
        {
            var returnValue = await _repository.CountAsync();
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetByAccountIdResponseDto>>> GetByAccountIdAsync(int cardAccountId, int? page, int? size)
        {
            var returnValue = await _repository.GetByAccountIdAsync(cardAccountId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetCardsWithTypeResponseDto>>> GetCardsWithTypeAsync(int cardTypesId, int cardsAccountId, int cardsCardTypeId, int? page, int? size)
        {
            var returnValue = await _repository.GetCardsWithTypeAsync(cardTypesId, cardsAccountId, cardsCardTypeId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetExpiredCardsResponseDto>>> GetExpiredCardsAsync(CardStatus cardStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetExpiredCardsAsync(cardStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ActivateCardAsync(int cardId, ActivateCardRequestDto updateRequest)
        {
            var returnValue = await _repository.ActivateCardAsync(cardId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> BlockCardAsync(int cardId, BlockCardRequestDto updateRequest)
        {
            var returnValue = await _repository.BlockCardAsync(cardId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ReportLostOrStolenAsync(int cardId, ReportLostOrStolenRequestDto updateRequest)
        {
            var returnValue = await _repository.ReportLostOrStolenAsync(cardId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}