using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralAxisAir.Notifications
{
    public interface ISmsService
    {
        void SendTextMessage(string phoneNumber, string message);
    }
}
