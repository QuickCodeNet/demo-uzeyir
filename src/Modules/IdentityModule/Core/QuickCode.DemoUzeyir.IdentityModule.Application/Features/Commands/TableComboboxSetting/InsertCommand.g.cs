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
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.TableComboboxSetting;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.TableComboboxSetting
{
    public class InsertTableComboboxSettingCommand : IRequest<Response<TableComboboxSettingDto>>
    {
        public TableComboboxSettingDto request { get; set; }

        public InsertTableComboboxSettingCommand(TableComboboxSettingDto request)
        {
            this.request = request;
        }

        public class InsertTableComboboxSettingHandler : IRequestHandler<InsertTableComboboxSettingCommand, Response<TableComboboxSettingDto>>
        {
            private readonly ILogger<InsertTableComboboxSettingHandler> _logger;
            private readonly ITableComboboxSettingRepository _repository;
            public InsertTableComboboxSettingHandler(ILogger<InsertTableComboboxSettingHandler> logger, ITableComboboxSettingRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<TableComboboxSettingDto>> Handle(InsertTableComboboxSettingCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}