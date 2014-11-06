using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NeuralAxis.Blog.ExternalApis
{
    public class DelayNotifications
    { 
        public void NotifyDelay(Passenger passenger, Delay delay)
        {
            var message = String.Format("El vuelo {0} a sido retrasado hasta las {1}.", delay.FlightId, delay.NewTime);
            var data = new NameValueCollection
                {
                    {"Body", message},
                    {"To", passenger.PhoneNumber},
                    {"From", "800-OUR-NUMR"}
                };

            var webClient = new WebClient();
            webClient.UploadValues(
                new Uri(
                    "https://api.twilio.com/2010-04-01/Accounts/{APIKEY}/SMS/Messages.json"),
                "POST", data);
        }
    }
}
