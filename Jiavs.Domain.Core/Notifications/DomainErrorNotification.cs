using Jiavs.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Core.Notifications
{
    /// <summary>
    /// 领域异常通知消息对象
    /// </summary>
    public class DomainErrorNotification : BaseEvent
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainErrorNotification(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}