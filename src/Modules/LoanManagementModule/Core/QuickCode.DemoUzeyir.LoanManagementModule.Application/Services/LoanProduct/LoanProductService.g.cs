using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.LoanManagementModule.Application.Dtos.LoanProduct;
using QuickCode.DemoUzeyir.LoanManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.LoanManagementModule.Application.Services.LoanProduct
{
    public partial class LoanProductService : ILoanProductService
    {
        private readonly ILogger<LoanProductService> _logger;
        private readonly ILoanProductRepository _repository;
        public LoanProductService(ILogger<LoanProductService> logger, ILoanProductRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<LoanProductDto>> InsertAsync(LoanProductDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(LoanProductDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, LoanProductDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<LoanProductDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<LoanProductDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool loanProductIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(loanProductIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string loanProductCode)
        {
            var returnValue = await _repository.GetByCodeAsync(loanProductCode);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> UpdateInterestRateAsync(int loanProductId, UpdateInterestRateRequestDto updateRequest)
        {
            var returnValue = await _repository.UpdateInterestRateAsync(loanProductId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int loanProductId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(loanProductId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}