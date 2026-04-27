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
    public partial class ContactDetailService : IContactDetailService
    {
        private readonly ILogger<ContactDetailService> _logger;
        private readonly IContactDetailRepository _repository;
        public ContactDetailService(ILogger<ContactDetailService> logger, IContactDetailRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<ContactDetailDto>> InsertAsync(ContactDetailDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(ContactDetailDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, ContactDetailDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<ContactDetailDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<ContactDetailDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetByCustomerIdResponseDto>>> GetByCustomerIdAsync(int contactDetailCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetByCustomerIdAsync(contactDetailCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetUnverifiedContactsResponseDto>>> GetUnverifiedContactsAsync(bool contactDetailIsVerified, int? page, int? size)
        {
            var returnValue = await _repository.GetUnverifiedContactsAsync(contactDetailIsVerified, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> MarkAsVerifiedAsync(int contactDetailId, MarkAsVerifiedRequestDto updateRequest)
        {
            var returnValue = await _repository.MarkAsVerifiedAsync(contactDetailId, updateRequest);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> RemoveContactAsync(int contactDetailId, int contactDetailCustomerId)
        {
            var returnValue = await _repository.RemoveContactAsync(contactDetailId, contactDetailCustomerId);
            return returnValue.ToResponse();
        }
    }
}