using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Dtos.CustomerType;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Application.Services.CustomerType
{
    public partial class CustomerTypeService : ICustomerTypeService
    {
        private readonly ILogger<CustomerTypeService> _logger;
        private readonly ICustomerTypeRepository _repository;
        public CustomerTypeService(ILogger<CustomerTypeService> logger, ICustomerTypeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<CustomerTypeDto>> InsertAsync(CustomerTypeDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(CustomerTypeDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, CustomerTypeDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<CustomerTypeDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<CustomerTypeDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool customerTypeIsActive, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveAsync(customerTypeIsActive, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string customerTypeCode)
        {
            var returnValue = await _repository.GetByCodeAsync(customerTypeCode);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> DeactivateAsync(int customerTypeId, DeactivateRequestDto updateRequest)
        {
            var returnValue = await _repository.DeactivateAsync(customerTypeId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}