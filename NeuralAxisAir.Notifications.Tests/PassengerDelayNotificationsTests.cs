using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
        private Mock<ISmsService> _sms;
        private PassengerNotifications _notifications;
        private Delay _delay;
        private Passenger _passenger;

        [TestInitialize]
        public void Setup()
        {
            _sms = new Mock<ISmsService>();
            _notifications = new PassengerNotifications(_sms.Object);
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
        [ExpectedException(typeof(Exception))]
        public void DoesNotTrapExceptionsWhenSendingSmsMessages()
        {
            this._sms.Setup(x => x.SendTextMessage(It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());
            _notifications.NotifyDelay(_passenger, _delay);
        }

        [TestMethod]
        public void SendsTextMessages()
        {
            _notifications.NotifyDelay(_passenger, _delay);
            _notifications.NotifyDelay(_passenger, _delay);
            _notifications.NotifyDelay(_passenger, _delay);
            this._sms.Verify(x => x.SendTextMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(3));
        }

        [TestMethod]
        public void SendsToCorrectPhoneNumber()
        {
            _notifications.NotifyDelay(_passenger, _delay);
            this._sms.Verify(x => x.SendTextMessage(_passenger.PhoneNumber, It.IsAny<string>()), Times.Once());
        }
        
        [TestMethod]
        public void SendsCorrectMessage()
        {
            var expectedMessage = "El vuelo 123 a sido retrasado hasta las 4:35 PM.";
            _notifications.NotifyDelay(_passenger, _delay);
            this._sms.Verify(x => x.SendTextMessage(It.IsAny<string>(), expectedMessage), Times.Once());
        }
    }
}
