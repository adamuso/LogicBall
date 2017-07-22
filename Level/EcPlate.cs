using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall.Level
{
    public class EcPlate : Sprite
    {
        private List<IEcConnector> connections;
        private bool done;
        private bool toggle;

        public EcPlate()
        {
            texture = Game.TextureManager.WallTexture;
            color = Color.Yellow;
            solid = false;
            drawingArea = new Rectangle(0, 0, 32, 32);

            connections = new List<IEcConnector>();
            done = false;
            toggle = true;
        }

        public override void Collide(Sprite sprite)
        {
            base.Collide(sprite);

            if(!done)
            {
                color = Color.Green;
                done = true;

                foreach(IEcConnector conn in connections)
                    conn.SendSignal(true);
            }
            else if(done && toggle)
            {
                color = Color.White;
                done = false;

                foreach (IEcConnector conn in connections)
                    conn.SendSignal(false);
            }
        }

        public void AddConnection(IEcConnector conn)
        {
            connections.Add(conn);
        }
    }
}
