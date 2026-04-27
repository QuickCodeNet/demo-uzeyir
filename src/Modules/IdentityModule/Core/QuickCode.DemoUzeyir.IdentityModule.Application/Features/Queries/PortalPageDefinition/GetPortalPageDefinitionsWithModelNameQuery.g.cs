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
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.PortalPageDefinition;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.PortalPageDefinition
{
    public class GetPortalPageDefinitionsWithModelNameQuery : IRequest<Response<List<GetPortalPageDefinitionsWithModelNameResponseDto>>>
    {
        public string PortalPageDefinitionModelName { get; set; }

        public GetPortalPageDefinitionsWithModelNameQuery(string portalPageDefinitionModelName)
        {
            this.PortalPageDefinitionModelName = portalPageDefinitionModelName;
        }

        public class GetPortalPageDefinitionsWithModelNameHandler : IRequestHandler<GetPortalPageDefinitionsWithModelNameQuery, Response<List<GetPortalPageDefinitionsWithModelNameResponseDto>>>
        {
            private readonly ILogger<GetPortalPageDefinitionsWithModelNameHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public GetPortalPageDefinitionsWithModelNameHandler(ILogger<GetPortalPageDefinitionsWithModelNameHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetPortalPageDefinitionsWithModelNameResponseDto>>> Handle(GetPortalPageDefinitionsWithModelNameQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageDefinitionsWithModelNameAsync(request.PortalPageDefinitionModelName);
                return returnValue.ToResponse();
            }
        }
    }
}