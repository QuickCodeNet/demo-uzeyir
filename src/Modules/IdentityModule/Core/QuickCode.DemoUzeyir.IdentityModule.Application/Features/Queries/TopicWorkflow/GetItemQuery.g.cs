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
using QuickCode.DemoUzeyir.IdentityModule.Application.Dtos.TopicWorkflow;
using QuickCode.DemoUzeyir.IdentityModule.Domain.Enums;

namespace QuickCode.DemoUzeyir.IdentityModule.Application.Features.TopicWorkflow
{
    public class GetItemTopicWorkflowQuery : IRequest<Response<TopicWorkflowDto>>
    {
        public int Id { get; set; }

        public GetItemTopicWorkflowQuery(int id)
        {
            this.Id = id;
        }

        public class GetItemTopicWorkflowHandler : IRequestHandler<GetItemTopicWorkflowQuery, Response<TopicWorkflowDto>>
        {
            private readonly ILogger<GetItemTopicWorkflowHandler> _logger;
            private readonly ITopicWorkflowRepository _repository;
            public GetItemTopicWorkflowHandler(ILogger<GetItemTopicWorkflowHandler> logger, ITopicWorkflowRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<TopicWorkflowDto>> Handle(GetItemTopicWorkflowQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Id);
                return returnValue.ToResponse();
            }
        }
    }
}