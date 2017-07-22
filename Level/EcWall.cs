using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall.Level
{
    public class EcWall : Wall, IEcConnector
    {
        public EcWall()
            : base()
        {
            color = Color.Red;
        }

        public void SendSignal(bool enabled)
        {
            if(enabled)
            {
                collisionable = false;
                color = new Color(40, 40, 40);
            }
            else
            {
                collisionable = true;
                color = Color.Red;
            }
        }
    }
}
