using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Twilio;

namespace HelpOut.Domain.Twilio
{
    public class RestClient
    {
        private readonly TwilioRestClient _client;

        private readonly string _accountSid = WebConfigurationManager.AppSettings["AccountSid"];
        private readonly string _authToken = WebConfigurationManager.AppSettings["AuthToken"];
        private readonly string _twilioNumber = WebConfigurationManager.AppSettings["TwilioNumber"];

        public RestClient()
        {
            _client = new TwilioRestClient(_accountSid, _authToken);
        }

        public void SendSmsMessage(string phoneNumber, string message)
        {
            _client.SendMessage(_twilioNumber, phoneNumber, message);
        }

    }
}
