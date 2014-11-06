using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NeuralAxisAir.Notifications.Tests
{
    class StubSmsService : ISmsService
    {
        public string SentPhoneNumber;
        public string SentMessage;
        public int NumberOfCalls;

        public void SendTextMessage(string phoneNumber, string message)
        {
            SentPhoneNumber = phoneNumber;
            SentMessage = message;
            this.NumberOfCalls += 1;
        }
    }

    [TestClass]
    public class PassengerNotificationsTests
    {
        private StubSmsService _sms;
        private PassengerNotifications _notifications;
        private Delay _delay;
        private Passenger _passenger;
        [TestInitialize]
        public void Setup()
        {
            _sms = new StubSmsService();
            _notifications = new PassengerNotifications(_sms);
            _delay = new Delay
            {
                FlightId = "123",
                NewTime = DateTime.Parse("4:35 PM")
            };
            _passenger = new Passenger
            {
                PhoneNumber = "555-123-1233"
            };
        }

        [TestMethod]
        public void SendsTextMessages()
        {
            _notifications.NotifyDelay(_passenger, _delay);
            _notifications.NotifyDelay(_passenger, _delay);
            _notifications.NotifyDelay(_passenger, _delay);
            Assert.AreEqual(3, _sms.NumberOfCalls);
        }

        [TestMethod]
        public void SendsToCorrectPhoneNumber()
        {
            _notifications.NotifyDelay(_passenger, _delay);
            Assert.AreEqual(_passenger.PhoneNumber, _sms.SentPhoneNumber);
        }
        
        [TestMethod]
        public void SendsCorrectMessage()
        {
            _notifications.NotifyDelay(_passenger, _delay);
            Assert.AreEqual(_passenger.PhoneNumber, _sms.SentPhoneNumber);

            Assert.AreEqual("El vuelo 123 a sido retrasado hasta las 4:35 PM.", _sms.SentMessage);
        }
    }
}
