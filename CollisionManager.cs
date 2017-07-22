using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall
{
    public class CollisionManager
    {
        private SpriteManager spriteManager;

        public CollisionManager(SpriteManager spriteManager)
        {
            this.spriteManager = spriteManager;
        }

        public bool Check(Sprite sp1, Sprite sp2)
        {
            return sp1.CollisionArea.Intersects(sp2.CollisionArea) && sp1.Collisionable && sp2.Collisionable;
        }

        public Sprite Find(Sprite sp)
        {
            foreach(Sprite spi in spriteManager.Sprites)
            {
                if (Check(sp, spi) && sp != spi)
                    return spi;
            }

            return null;
        }
    }
}
