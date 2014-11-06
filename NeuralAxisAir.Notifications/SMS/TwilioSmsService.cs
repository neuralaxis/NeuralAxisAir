using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NeuralAxisAir.Notifications.SMS
{
    public class TwilioSmsService : ISmsService
    {
        public void SendTextMessage(string phoneNumber, string message)
        {
            var webClient = new WebClient();
            var data = new NameValueCollection
                {
                    {"Body", message},
                    {"To", phoneNumber},
                    {"From", "800-OUR-NUMR"}
                };

            webClient.UploadValues(
                new Uri(
                    "https://api.twilio.com/2010-04-01/Accounts/AC5ef8732a3c49700934481addd5ce1659/SMS/Messages.json"),
                "POST", data);
        }
    }
}
