using Jiavs.Domain.Core.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jiavs.Domain.Core.NotificationHandlers
{
    /// <summary>
    /// 领域异常通知处理器基类
    /// </summary>
    public class DomainErrorNotificationHandler : INotificationHandler<DomainErrorNotification>
    {
        private List<DomainErrorNotification> _errorNotifications;

        public DomainErrorNotificationHandler()
        {
            _errorNotifications = new List<DomainErrorNotification>();
        }

        public Task Handle(DomainErrorNotification notification, CancellationToken cancellationToken)
        {
            _errorNotifications.Add(notification);
            return Task.CompletedTask;
        }

        public List<DomainErrorNotification> GetErrorNotifications(string key = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                return _errorNotifications;
            }
            else
            {
                return _errorNotifications.FindAll(n => string.Equals(n.Key, key));
            }
        }

        public bool HasDomainErrors(string key = null)
        {
            return GetErrorNotifications(key).Count > 0;
        }

        public void ClearDomainErrors(string key = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                _errorNotifications.Clear();
            }
            else
            {
                for (int i = _errorNotifications.Count - 1; i >= 0; i--)
                {
                    if (string.Equals(_errorNotifications[i].Key, key))
                    {
                        _errorNotifications.RemoveAt(i);
                    }
                }
            }
        }
    }
}