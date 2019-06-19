using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jiavs.Domain.Core.Bus;
using Jiavs.Domain.Core.Commands;
using Jiavs.Domain.Core.Events;
using MediatR;
namespace Jiavs.Infrastructure.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }
        public Task RaiseEvent<T>(T evt) where T : BaseEvent
        {
            return _mediator.Publish<T>(evt);
        }

        public Task SendCommand<T>(T cmd) where T : BaseCommand
        {
            return _mediator.Send(cmd);
        }
    }
}
