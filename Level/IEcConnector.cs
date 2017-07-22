using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall.Level
{
    public interface IEcConnector
    {
        void SendSignal(bool enabled);
    }
}
