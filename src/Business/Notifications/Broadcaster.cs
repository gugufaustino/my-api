using Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Notifications
{
    public class Broadcaster : IBroadcaster
    {
        private List<Notification> _notifications;
        public Broadcaster()
        {
            _notifications = new List<Notification>();
        }
        public List<Notification> GetNotifications(TypeNotification typeNotification)
        {
            return _notifications.Where(i=> i.TypeNotification == typeNotification).ToList();
        }

        public bool HasNotifications(TypeNotification typeNotification)
        {
            return _notifications.Any(i=> i.TypeNotification == typeNotification);
        }

        public void ToTransmit(Notification notification)
        {
            _notifications.Add(notification);
        }
    }
}
