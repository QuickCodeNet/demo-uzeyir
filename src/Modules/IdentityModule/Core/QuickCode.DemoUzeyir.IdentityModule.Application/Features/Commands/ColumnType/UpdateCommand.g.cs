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
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.ColumnType;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.ColumnType
{
    public class UpdateColumnTypeCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }
        public ColumnTypeDto request { get; set; }

        public UpdateColumnTypeCommand(int id, ColumnTypeDto request)
        {
            this.request = request;
            this.Id = id;
        }

        public class UpdateColumnTypeHandler : IRequestHandler<UpdateColumnTypeCommand, Response<bool>>
        {
            private readonly ILogger<UpdateColumnTypeHandler> _logger;
            private readonly IColumnTypeRepository _repository;
            public UpdateColumnTypeHandler(ILogger<UpdateColumnTypeHandler> logger, IColumnTypeRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(UpdateColumnTypeCommand request, CancellationToken cancellationToken)
            {
                var updateItem = await _repository.GetByPkAsync(request.Id);
                if (updateItem.Code == 404)
                    return Response<bool>.NotFound();
                var model = request.request;
                var returnValue = await _repository.UpdateAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}