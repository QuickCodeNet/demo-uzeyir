using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Entities;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Dtos.Beneficiary;
using QuickCode.DemoUzeyir.TransactionProcessingModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.TransactionProcessingModule.Application.Services.Beneficiary
{
    public partial class BeneficiaryService : IBeneficiaryService
    {
        private readonly ILogger<BeneficiaryService> _logger;
        private readonly IBeneficiaryRepository _repository;
        public BeneficiaryService(ILogger<BeneficiaryService> logger, IBeneficiaryRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<BeneficiaryDto>> InsertAsync(BeneficiaryDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(BeneficiaryDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, BeneficiaryDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<BeneficiaryDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<BeneficiaryDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int beneficiaryCustomerId, bool beneficiaryIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerIdAsync(beneficiaryCustomerId, beneficiaryIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNicknameResponseDto>>> SearchByNicknameAsync(int beneficiaryCustomerId, string beneficiaryNickname, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNicknameAsync(beneficiaryCustomerId, beneficiaryNickname, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int beneficiaryId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(beneficiaryId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}