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
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.ApiMethodDefinition;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.ApiMethodDefinition
{
    public class ExistsApiMethodDefinitionsWithModelNameQuery : IRequest<Response<bool>>
    {
        public string ApiMethodDefinitionModelName { get; set; }

        public ExistsApiMethodDefinitionsWithModelNameQuery(string apiMethodDefinitionModelName)
        {
            this.ApiMethodDefinitionModelName = apiMethodDefinitionModelName;
        }

        public class ExistsApiMethodDefinitionsWithModelNameHandler : IRequestHandler<ExistsApiMethodDefinitionsWithModelNameQuery, Response<bool>>
        {
            private readonly ILogger<ExistsApiMethodDefinitionsWithModelNameHandler> _logger;
            private readonly IApiMethodDefinitionRepository _repository;
            public ExistsApiMethodDefinitionsWithModelNameHandler(ILogger<ExistsApiMethodDefinitionsWithModelNameHandler> logger, IApiMethodDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(ExistsApiMethodDefinitionsWithModelNameQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ExistsApiMethodDefinitionsWithModelNameAsync(request.ApiMethodDefinitionModelName);
                return returnValue.ToResponse();
            }
        }
    }
}