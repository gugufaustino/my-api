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
        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public void ToTransmit(Notification notification)
        {
            _notifications.Add(notification);
        }
    }
}
