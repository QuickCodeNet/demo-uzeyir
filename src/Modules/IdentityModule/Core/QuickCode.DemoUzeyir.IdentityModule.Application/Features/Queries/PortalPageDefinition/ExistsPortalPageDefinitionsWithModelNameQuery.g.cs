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
    public class ExistsPortalPageDefinitionsWithModelNameQuery : IRequest<Response<bool>>
    {
        public string PortalPageDefinitionModelName { get; set; }

        public ExistsPortalPageDefinitionsWithModelNameQuery(string portalPageDefinitionModelName)
        {
            this.PortalPageDefinitionModelName = portalPageDefinitionModelName;
        }

        public class ExistsPortalPageDefinitionsWithModelNameHandler : IRequestHandler<ExistsPortalPageDefinitionsWithModelNameQuery, Response<bool>>
        {
            private readonly ILogger<ExistsPortalPageDefinitionsWithModelNameHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public ExistsPortalPageDefinitionsWithModelNameHandler(ILogger<ExistsPortalPageDefinitionsWithModelNameHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(ExistsPortalPageDefinitionsWithModelNameQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ExistsPortalPageDefinitionsWithModelNameAsync(request.PortalPageDefinitionModelName);
                return returnValue.ToResponse();
            }
        }
    }
}