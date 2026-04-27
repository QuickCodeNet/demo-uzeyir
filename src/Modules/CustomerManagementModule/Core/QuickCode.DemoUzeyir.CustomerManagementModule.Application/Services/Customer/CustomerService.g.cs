using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Dtos.Customer;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Application.Services.Customer
{
    public partial class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly ICustomerRepository _repository;
        public CustomerService(ILogger<CustomerService> logger, ICustomerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<CustomerDto>> InsertAsync(CustomerDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(CustomerDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, CustomerDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<CustomerDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<CustomerDto>> GetItemAsync(int id)
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

        public async Task<Response<GetByCustomerNumberResponseDto>> GetByCustomerNumberAsync(Guid customerCustomerNumber)
        {
            var returnValue = await _repository.GetByCustomerNumberAsync(customerCustomerNumber);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string customerLastName, int? page, int? size)
        {
            var returnValue = await _repository.SearchByNameAsync(customerLastName, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetActiveCustomersResponseDto>>> GetActiveCustomersAsync(CustomerStatus customerStatus, int? page, int? size)
        {
            var returnValue = await _repository.GetActiveCustomersAsync(customerStatus, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetCustomersByTypeResponseDto>>> GetCustomersByTypeAsync(int customersCustomerTypeId, int customerTypesId, int? page, int? size)
        {
            var returnValue = await _repository.GetCustomersByTypeAsync(customersCustomerTypeId, customerTypesId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRecentlyJoinedResponseDto>>> GetRecentlyJoinedAsync(int? page, int? size)
        {
            var returnValue = await _repository.GetRecentlyJoinedAsync(page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<long>> GetActiveCountByTypeAsync(int customersCustomerTypeId, CustomerStatus customersStatus, int customerTypesId)
        {
            var returnValue = await _repository.GetActiveCountByTypeAsync(customersCustomerTypeId, customersStatus, customerTypesId);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> ActivateCustomerAsync(int customerId, ActivateCustomerRequestDto updateRequest)
        {
            var returnValue = await _repository.ActivateCustomerAsync(customerId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> SuspendCustomerAsync(int customerId, SuspendCustomerRequestDto updateRequest)
        {
            var returnValue = await _repository.SuspendCustomerAsync(customerId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> CloseCustomerAsync(int customerId, CloseCustomerRequestDto updateRequest)
        {
            var returnValue = await _repository.CloseCustomerAsync(customerId, updateRequest);
            return returnValue.ToResponse();
        }
    }
}