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
    public partial interface ICustomerRelationshipService
    {
        Task<Response<CustomerRelationshipDto>> InsertAsync(CustomerRelationshipDto request);
        Task<Response<bool>> DeleteAsync(CustomerRelationshipDto request);
        Task<Response<bool>> UpdateAsync(int id, CustomerRelationshipDto request);
        Task<Response<List<CustomerRelationshipDto>>> ListAsync(int? pageNumber, int? pageSize);
        Task<Response<CustomerRelationshipDto>> GetItemAsync(int id);
        Task<Response<bool>> DeleteItemAsync(int id);
        Task<Response<int>> TotalItemCountAsync();
        Task<Response<List<GetRelationshipsByCustomerIdResponseDto>>> GetRelationshipsByCustomerIdAsync(int customerRelationshipPrimaryCustomerId, int? page, int? size);
        Task<Response<List<GetRelatedCustomersResponseDto>>> GetRelatedCustomersAsync(int customerRelationshipsPrimaryCustomerId, int customerRelationshipsRelatedCustomerId, int customersId, int? page, int? size);
        Task<Response<int>> RemoveRelationshipAsync(int customerRelationshipId);
    }
}