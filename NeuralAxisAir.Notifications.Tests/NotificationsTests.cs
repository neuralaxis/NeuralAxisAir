using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralAxis.Blog.ExternalApis;

namespace NeuralAxisAir.Notifications.Tests
{
    [TestClass]
    public class NotificationsTests
    {
        [TestMethod]
        public void SendsTextMessages()
        {
            var delay = new Delay
            {
                FlightId = "123",
                NewTime = DateTime.Now
            };

            var passenger = new Passenger
            {
                PhoneNumber = "555-123-1233"
            };

            var notifications = new DelayNotifications();

            notifications.NotifyDelay(passenger,delay);
        }
    }
}
