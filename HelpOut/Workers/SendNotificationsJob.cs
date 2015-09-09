using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpOut.Models;
using WebGrease.Css.Extensions;
using HelpOut.Domain;
using System.Data.Entity;

namespace HelpOut.Workers
{
    public class SendNotificationsJob
    {
        private const string MessageTemplate = "Hey, {0}! You've got {1} coming up at {2} today. Go to http://helpout.azurewebsites.com for details!";

        public void Execute()
        {
            var twilioRestClient = new Domain.Twilio.RestClient();

            var upcoming = UpcomingEvents();
            foreach(Event e in upcoming)
            {
                foreach (ApplicationUser attendee in e.Attendees)
                {
                    twilioRestClient.SendSmsMessage(attendee.PhoneNumber,
                        string.Format(MessageTemplate, attendee.FullName,
                        e.DateTime.ToString("t")));
                }
            }    
        }

        private static List<Event> UpcomingEvents()
        {
            var db = new ApplicationDbContext();
            var allEvents = (from e in db.Events
                            select e).Include("Attendees");
            
            var upcoming = new List<Event>();

            foreach(Event e in allEvents)
            {
                var willSend = new SMSNotificationPolicy(e).NeedsToBeSent(DateTime.Now);
                if (willSend)
                {
                    upcoming.Add(e);
                }
            }

            return upcoming;
                                      
        }


    }
}
