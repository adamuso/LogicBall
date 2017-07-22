using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall
{
    public abstract class MoveableSprite : Sprite
    {
        private Vector2 bufferedPos;
        protected Vector2 velocity;

        public MoveableSprite() : base()
        {
            bufferedPos = Vector2.Zero;
        }

        public void RebufferPosition()
        {
            this.bufferedPos = this.position;
        }

        public void ApplyPosition()
        {
            this.position = bufferedPos;
        }
        
        public void MoveBuffer(float x, float y)
        {
            bufferedPos.X += x;
            bufferedPos.Y += y;
        }

        public void MoveBuffer(Vector2 offset)
        {
            bufferedPos += offset;
        }

        protected Vector2 BufferedPosition { get { return bufferedPos; } }
        public override Vector2 Position { get { return base.Position; } set { base.Position = value; bufferedPos = value; } }
        public Vector2 Velocity { get { return velocity; } }
        public override Rectangle CollisionArea { get { return new Rectangle((int)bufferedPos.X, (int)bufferedPos.Y, base.CollisionArea.Width, base.CollisionArea.Height); } }
    }
}
