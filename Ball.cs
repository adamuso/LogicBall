using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall
{
    public class Ball : MoveableSprite
    {
        //private Vector2 velocity;
        private Vector2 expectedVelocity;
        private List<Sprite> lastCollisions;

        public Ball() : base()
        {
            texture = Game.TextureManager.BallTexture;
            drawingArea = new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32);
            lastCollisions = new List<Sprite>();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gt)
        {
            base.Update(gt);

            if (velocity.X == 0 && velocity.Y == 0)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    Move(10, 0);
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    Move(-10, 0);
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    Move(0, -10);
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    Move(0, 10);
            }

            RebufferPosition();

            if (velocity.Length() < expectedVelocity.Length())
                velocity += expectedVelocity / 20;

            base.MoveBuffer(velocity);

            Sprite coll;

            Game.ParticleManager.GenerateBallFlame(this);
  
            if((coll = Game.CollisionManager.Find(this)) != null)
            {
                if(!lastCollisions.Contains(coll))
                {
                    lastCollisions.Add(coll);

                    coll.Collide(this);
                }

                if (coll.Solid)
                {
                    RebufferPosition();

                    velocity.Normalize();

                    while (Game.CollisionManager.Find(this) == null)
                    {
                        base.MoveBuffer(velocity);
                    }

                    base.MoveBuffer(-velocity);

                    if (base.Position != base.BufferedPosition)
                        Game.ParticleManager.GenerateBallExplosion(this, color);

                    velocity = Vector2.Zero;
                    expectedVelocity = Vector2.Zero;
                }
            }
            else
                lastCollisions.Clear();
            
            ApplyPosition();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            //base.Draw(sb);
        }

        public void Move(float xvel, float yvel)
        {
            this.expectedVelocity.X = xvel;
            this.expectedVelocity.Y = yvel;
        }

        //public Vector2 Velocity { get { return velocity; } }
    }
}
