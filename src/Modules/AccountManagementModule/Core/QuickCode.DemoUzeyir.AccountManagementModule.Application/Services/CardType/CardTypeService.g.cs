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
    public partial class CardTypeService : ICardTypeService
    {
        private readonly ILogger<CardTypeService> _logger;
        private readonly ICardTypeRepository _repository;
        public CardTypeService(ILogger<CardTypeService> logger, ICardTypeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<CardTypeDto>> InsertAsync(CardTypeDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(CardTypeDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, CardTypeDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<CardTypeDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<CardTypeDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool cardTypeIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(cardTypeIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string cardTypeCode)
        {
            var returnValue = await _repository.GetByCodeAsync(cardTypeCode);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int cardTypeId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(cardTypeId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}