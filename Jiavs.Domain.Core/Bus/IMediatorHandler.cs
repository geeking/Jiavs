using Jiavs.Domain.Core.Commands;
using Jiavs.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jiavs.Domain.Core.Bus
{
    /// <summary>
    /// 消息中介者接口
    /// 用于消息分发
    /// </summary>
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T cmd) where T : BaseCommand;
        Task RaiseEvent<T>(T evt) where T : BaseEvent;
    }
}
