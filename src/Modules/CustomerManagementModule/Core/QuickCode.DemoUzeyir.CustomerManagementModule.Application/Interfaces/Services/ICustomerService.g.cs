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
    public partial interface ICustomerService
    {
        Task<Response<CustomerDto>> InsertAsync(CustomerDto request);
        Task<Response<bool>> DeleteAsync(CustomerDto request);
        Task<Response<bool>> UpdateAsync(int id, CustomerDto request);
        Task<Response<List<CustomerDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CustomerDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<GetByCustomerNumberResponseDto>> GetByCustomerNumberAsync(Guid customerCustomerNumber);
        Task<Response<List<SearchByNameResponseDto>>> SearchByNameAsync(string customerLastName, int? page, int? size);
        Task<Response<List<GetActiveCustomersResponseDto>>> GetActiveCustomersAsync(CustomerStatus customerStatus, int? page, int? size);
        Task<Response<List<GetCustomersByTypeResponseDto>>> GetCustomersByTypeAsync(int customersCustomerTypeId, int customerTypesId, int? page, int? size);
        Task<Response<List<GetRecentlyJoinedResponseDto>>> GetRecentlyJoinedAsync(int? page, int? size);
        Task<Response<long>> GetActiveCountByTypeAsync(int customersCustomerTypeId, CustomerStatus customersStatus, int customerTypesId);
        Task<Response<int>> ActivateCustomerAsync(int customerId, ActivateCustomerRequestDto updateRequest);
        Task<Response<int>> SuspendCustomerAsync(int customerId, SuspendCustomerRequestDto updateRequest);
        Task<Response<int>> CloseCustomerAsync(int customerId, CloseCustomerRequestDto updateRequest);
    }
}