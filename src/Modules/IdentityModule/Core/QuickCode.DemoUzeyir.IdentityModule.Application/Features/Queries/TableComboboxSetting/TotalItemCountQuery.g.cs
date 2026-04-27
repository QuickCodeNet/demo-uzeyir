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
    public class TotalCountTableComboboxSettingQuery : IRequest<Response<int>>
    {
        public TotalCountTableComboboxSettingQuery()
        {
        }

        public class TotalCountTableComboboxSettingHandler : IRequestHandler<TotalCountTableComboboxSettingQuery, Response<int>>
        {
            private readonly ILogger<TotalCountTableComboboxSettingHandler> _logger;
            private readonly ITableComboboxSettingRepository _repository;
            public TotalCountTableComboboxSettingHandler(ILogger<TotalCountTableComboboxSettingHandler> logger, ITableComboboxSettingRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountTableComboboxSettingQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}