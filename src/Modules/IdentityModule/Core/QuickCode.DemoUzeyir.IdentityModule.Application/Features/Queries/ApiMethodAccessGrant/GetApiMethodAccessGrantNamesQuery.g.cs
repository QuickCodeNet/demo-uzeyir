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
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.ApiMethodAccessGrant;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.ApiMethodAccessGrant
{
    public class GetApiMethodAccessGrantNamesQuery : IRequest<Response<List<GetApiMethodAccessGrantNamesResponseDto>>>
    {
        public string ApiMethodAccessGrantPermissionGroupName { get; set; }

        public GetApiMethodAccessGrantNamesQuery(string apiMethodAccessGrantPermissionGroupName)
        {
            this.ApiMethodAccessGrantPermissionGroupName = apiMethodAccessGrantPermissionGroupName;
        }

        public class GetApiMethodAccessGrantNamesHandler : IRequestHandler<GetApiMethodAccessGrantNamesQuery, Response<List<GetApiMethodAccessGrantNamesResponseDto>>>
        {
            private readonly ILogger<GetApiMethodAccessGrantNamesHandler> _logger;
            private readonly IApiMethodAccessGrantRepository _repository;
            public GetApiMethodAccessGrantNamesHandler(ILogger<GetApiMethodAccessGrantNamesHandler> logger, IApiMethodAccessGrantRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetApiMethodAccessGrantNamesResponseDto>>> Handle(GetApiMethodAccessGrantNamesQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetApiMethodAccessGrantNamesAsync(request.ApiMethodAccessGrantPermissionGroupName);
                return returnValue.ToResponse();
            }
        }
    }
}