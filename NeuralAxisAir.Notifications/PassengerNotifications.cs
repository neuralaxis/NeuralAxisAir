using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NeuralAxisAir.Notifications
{
    public class PassengerNotifications
    {
        private ISmsService _sms;

        public PassengerNotifications(ISmsService sms)
        {
            this._sms = sms;
        }

        public void NotifyDelay(Passenger passenger, Delay delay)
        {
            var message = String.Format("El vuelo {0} a sido retrasado hasta las {1}.", delay.FlightId, delay.NewTime.ToShortTimeString());
            this._sms.SendTextMessage(passenger.PhoneNumber, message);
        }
    }
}
