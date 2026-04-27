using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Dtos.Address;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Application.Services.Address
{
    public partial interface IAddressService
    {
        Task<Response<AddressDto>> InsertAsync(AddressDto request);
        Task<Response<bool>> DeleteAsync(AddressDto request);
        Task<Response<bool>> UpdateAsync(int id, AddressDto request);
        Task<Response<List<AddressDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<AddressDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int addressCustomerId, int? page, int? size);
        Task<Response<GetPrimaryByCustomerIdResponseDto>> GetPrimaryByCustomerIdAsync(int addressCustomerId, bool addressIsPrimary);
        Task<Response<int>> SetAsPrimaryAsync(int addressId, int addressCustomerId, SetAsPrimaryRequestDto updateRequest);
        Task<Response<int>> UnsetPrimaryAsync(int addressCustomerId, UnsetPrimaryRequestDto updateRequest);
        Task<Response<int>> RemoveAddressAsync(int addressId, int addressCustomerId);
    }
}