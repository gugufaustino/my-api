using Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IBroadcaster
    {
        bool HasNotifications(TypeNotification typeNotification = TypeNotification.Error);
        List<Notification> GetNotifications(TypeNotification typeNotification = TypeNotification.Error);
        void ToTransmit(Notification notificacao);
    }
}
