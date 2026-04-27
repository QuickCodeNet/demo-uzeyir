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
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.PortalMenu;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.PortalMenu
{
    public class TotalCountPortalMenuQuery : IRequest<Response<int>>
    {
        public TotalCountPortalMenuQuery()
        {
        }

        public class TotalCountPortalMenuHandler : IRequestHandler<TotalCountPortalMenuQuery, Response<int>>
        {
            private readonly ILogger<TotalCountPortalMenuHandler> _logger;
            private readonly IPortalMenuRepository _repository;
            public TotalCountPortalMenuHandler(ILogger<TotalCountPortalMenuHandler> logger, IPortalMenuRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountPortalMenuQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}