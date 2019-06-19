using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Core.Events
{
    /// <summary>
    /// 事件的抽象基类，多播
    /// </summary>
    public abstract class BaseEvent : INotification
    {
        public Guid EventId { get; private set; }
        public DateTime Timestamp { get; private set; }

        protected BaseEvent()
        {
            EventId = Guid.NewGuid();
            Timestamp = DateTime.UtcNow;
        }
    }
}