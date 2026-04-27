using System;
using System.Linq;
using QuickCode.DemoUzeyir.Common.Mediator;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.DemoUzeyir.Common.Models;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Entities;
using QuickCode.DemoUzeyir.IdentityModule.Application.Interfaces.Repositories;
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.AspNetRoleClaim;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.AspNetRoleClaim
{
    public class ListAspNetRoleClaimQuery : IRequest<Response<List<AspNetRoleClaimDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public ListAspNetRoleClaimQuery(int? pageNumber, int? pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

        public class ListAspNetRoleClaimHandler : IRequestHandler<ListAspNetRoleClaimQuery, Response<List<AspNetRoleClaimDto>>>
        {
            private readonly ILogger<ListAspNetRoleClaimHandler> _logger;
            private readonly IAspNetRoleClaimRepository _repository;
            public ListAspNetRoleClaimHandler(ILogger<ListAspNetRoleClaimHandler> logger, IAspNetRoleClaimRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<AspNetRoleClaimDto>>> Handle(ListAspNetRoleClaimQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ListAsync(request.PageNumber, request.PageSize);
                return returnValue.ToResponse();
            }
        }
    }
}