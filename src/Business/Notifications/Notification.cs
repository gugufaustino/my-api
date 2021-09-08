using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Notifications
{
    public class Notification
    {
        public string Message { get; private set; }

        public Notification(string message)
        {
            Message = message;
        }
    }
}
