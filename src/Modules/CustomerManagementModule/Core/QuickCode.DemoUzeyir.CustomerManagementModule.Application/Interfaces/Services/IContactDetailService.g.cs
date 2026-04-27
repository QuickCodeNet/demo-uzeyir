using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Dtos.ContactDetail;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Application.Services.ContactDetail
{
    public partial interface IContactDetailService
    {
        Task<Response<ContactDetailDto>> InsertAsync(ContactDetailDto request);
        Task<Response<bool>> DeleteAsync(ContactDetailDto request);
        Task<Response<bool>> UpdateAsync(int id, ContactDetailDto request);
        Task<Response<List<ContactDetailDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<ContactDetailDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int contactDetailCustomerId, int? page, int? size);
        Task<Response<List<GetUnverifiedContactsResponseDto>>> GetUnverifiedContactsAsync(bool contactDetailIsVerified, int? page, int? size);
        Task<Response<int>> MarkAsVerifiedAsync(int contactDetailId, MarkAsVerifiedRequestDto updateRequest);
        Task<Response<int>> RemoveContactAsync(int contactDetailId, int contactDetailCustomerId);
    }
}