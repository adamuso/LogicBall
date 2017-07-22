using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall.Level
{
    public class MovingWall : MoveableSprite
    {
        //private Vector2 velocity;
        private Vector2 expectedVelocity;
        private Vector2 wallPosition;

        public MovingWall()
            : base()        
        {
            texture = Game.TextureManager.WallTexture;
            drawingArea = new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32);
            color = Color.Red;
        }

        public override void Collide(Sprite sprite)
        {
            base.Collide(sprite);
        
            if(sprite is Ball)
            {
                Ball ball = (Ball)sprite;

                this.expectedVelocity = ball.Velocity ;
                this.expectedVelocity.Normalize();
                this.expectedVelocity *= 10f;
                this.velocity = Vector2.Zero;
            }
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);

            RebufferPosition();

            if(velocity.Length() < expectedVelocity.Length())
                velocity += expectedVelocity / 100;

            MoveBuffer(velocity);

            Game.ParticleManager.GenerateBallFlame(this, new Color(color.ToVector3() * 0.2f));

            if (velocity.Length() > 0)
            {
                Sprite coll;
                //Game.ParticleManager.GenerateBallFlame(this);

                if ((coll = Game.CollisionManager.Find(this)) != null)
                {
                    if (coll.Solid)
                    {
                        RebufferPosition();
                        velocity.Normalize();
                        
                        while (Game.CollisionManager.Find(this) == null)
                        {
                            base.MoveBuffer(velocity);
                        }

                        base.MoveBuffer(-velocity);

                        velocity.X = 0;
                        velocity.Y = 0;
                        expectedVelocity = Vector2.Zero;

                        Game.ParticleManager.GenerateBallExplosion(this, new Color(color.ToVector3() * 0.2f));
                    }
                }
            }

            ApplyPosition();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            //base.Draw(sb);
        }

        public override Vector2 Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;
                wallPosition = value;
            }
        }
    }
}
