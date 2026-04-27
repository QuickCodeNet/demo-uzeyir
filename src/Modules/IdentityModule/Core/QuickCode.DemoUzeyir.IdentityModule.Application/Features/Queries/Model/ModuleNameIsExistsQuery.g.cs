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
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.Model;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.Model
{
    public class ModuleNameIsExistsQuery : IRequest<Response<bool>>
    {
        public string ModelModuleName { get; set; }

        public ModuleNameIsExistsQuery(string modelModuleName)
        {
            this.ModelModuleName = modelModuleName;
        }

        public class ModuleNameIsExistsHandler : IRequestHandler<ModuleNameIsExistsQuery, Response<bool>>
        {
            private readonly ILogger<ModuleNameIsExistsHandler> _logger;
            private readonly IModelRepository _repository;
            public ModuleNameIsExistsHandler(ILogger<ModuleNameIsExistsHandler> logger, IModelRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(ModuleNameIsExistsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ModuleNameIsExistsAsync(request.ModelModuleName);
                return returnValue.ToResponse();
            }
        }
    }
}