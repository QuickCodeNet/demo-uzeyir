using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Entities;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.CustomerManagementModule.Application.Dtos.CustomerRelationship;
using QuickCode.DemoUzeyir.CustomerManagementModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.CustomerManagementModule.Application.Services.CustomerRelationship
{
    public partial class CustomerRelationshipService : ICustomerRelationshipService
    {
        private readonly ILogger<CustomerRelationshipService> _logger;
        private readonly ICustomerRelationshipRepository _repository;
        public CustomerRelationshipService(ILogger<CustomerRelationshipService> logger, ICustomerRelationshipRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Response<CustomerRelationshipDto>> InsertAsync(CustomerRelationshipDto request)
        {
            var returnValue = await _repository.InsertAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> DeleteAsync(CustomerRelationshipDto request)
        {
            var returnValue = await _repository.DeleteAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<bool>> UpdateAsync(int id, CustomerRelationshipDto request)
        {
            var updateItem = await _repository.GetByPkAsync(request.Id);
            if (updateItem.Code == 404)
                return Response<bool>.NotFound();
            var returnValue = await _repository.UpdateAsync(request);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<CustomerRelationshipDto>>> ListAsync(int? pageNumber, int? pageSize)
        {
            var returnValue = await _repository.ListAsync(pageNumber, pageSize);
            return returnValue.ToResponse();
        }

        public async Task<Response<CustomerRelationshipDto>> GetItemAsync(int id)
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

        public async Task<Response<List<GetRelationshipsByCustomerIdResponseDto>>> GetRelationshipsByCustomerIdAsync(int customerRelationshipPrimaryCustomerId, int? page, int? size)
        {
            var returnValue = await _repository.GetRelationshipsByCustomerIdAsync(customerRelationshipPrimaryCustomerId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<List<GetRelatedCustomersResponseDto>>> GetRelatedCustomersAsync(int customerRelationshipsPrimaryCustomerId, int customerRelationshipsRelatedCustomerId, int customersId, int? page, int? size)
        {
            var returnValue = await _repository.GetRelatedCustomersAsync(customerRelationshipsPrimaryCustomerId, customerRelationshipsRelatedCustomerId, customersId, page, size);
            return returnValue.ToResponse();
        }

        public async Task<Response<int>> RemoveRelationshipAsync(int customerRelationshipId)
        {
            var returnValue = await _repository.RemoveRelationshipAsync(customerRelationshipId);
            return returnValue.ToResponse();
        }
    }
}