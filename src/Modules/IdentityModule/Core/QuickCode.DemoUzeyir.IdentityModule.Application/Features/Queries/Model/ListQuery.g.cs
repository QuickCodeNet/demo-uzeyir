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
    public class ListModelQuery : IRequest<Response<List<ModelDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public ListModelQuery(int? pageNumber, int? pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

        public class ListModelHandler : IRequestHandler<ListModelQuery, Response<List<ModelDto>>>
        {
            private readonly ILogger<ListModelHandler> _logger;
            private readonly IModelRepository _repository;
            public ListModelHandler(ILogger<ListModelHandler> logger, IModelRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<ModelDto>>> Handle(ListModelQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.ListAsync(request.PageNumber, request.PageSize);
                return returnValue.ToResponse();
            }
        }
    }
}