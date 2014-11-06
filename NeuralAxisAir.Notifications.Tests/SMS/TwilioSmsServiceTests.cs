using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralAxisAir.Notifications.SMS;

namespace NeuralAxisAir.Notifications.Tests.SMS
{
    [TestClass]
    public class TwilioSmsServiceTests
    {
        public const string QA_CELL_PHONE = "555-123-4444";
        
        [TestMethod]
        [TestCategory("Integration Test")]
        public void SendActualSMStoTwilio()
        {
            var twilio = new TwilioSmsService();
            twilio.SendTextMessage(QA_CELL_PHONE, "Hello from Twilio");
        }
    }
}
