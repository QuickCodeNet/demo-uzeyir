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
    public partial interface ICustomerTypeService
    {
        Task<Response<CustomerTypeDto>> InsertAsync(CustomerTypeDto request);
        Task<Response<bool>> DeleteAsync(CustomerTypeDto request);
        Task<Response<bool>> UpdateAsync(int id, CustomerTypeDto request);
        Task<Response<List<CustomerTypeDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CustomerTypeDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetActiveResponseDto>>> GetActiveAsync(bool customerTypeIsActive, int? page, int? size);
        Task<Response<GetByCodeResponseDto>> GetByCodeAsync(string customerTypeCode);
        Task<Response<int>> DeactivateAsync(int customerTypeId, DeactivateRequestDto updateRequest);
    }
}