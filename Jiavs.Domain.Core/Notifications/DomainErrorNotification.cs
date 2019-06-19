using Jiavs.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Domain.Core.Notifications
{
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