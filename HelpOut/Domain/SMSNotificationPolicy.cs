using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpOut.Models;

namespace HelpOut.Domain
{
    public class SMSNotificationPolicy
    {
        private readonly Event _event;

        public SMSNotificationPolicy(Event e)
        {
            _event = e;
        }

        public bool NeedsToBeSent(DateTime currentTime)
        {
            //notify volunteer 2 hours before event start
            var reminderTime = _event.DateTime.ToLocalTime().AddMinutes(-120);

            return currentTime.ToString("MM/dd/yyyy HH:mm") ==
                reminderTime.ToString("MM/dd/yyyy HH:mm");
        }
    }
}
