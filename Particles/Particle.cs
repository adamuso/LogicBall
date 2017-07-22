using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall.Particles
{
    public class Particle
    {
        private TextureSource texture;
        private int ttl, sttl;
        private Vector2 position;
        private Vector2 velocity;
        private Color color, scolor;
        private float scale;
        private float xfric, yfric;
        private ParticleForce force;

        public Particle(TextureSource texture, int ttl, Vector2 position, float xvel, float yvel, float xfriction, float yfricition, Color color, float scale)
        {
            this.texture = texture;
            this.ttl = ttl;
            this.sttl = ttl;
            this.position = position;
            //this.xvel = xvel;
            //this.yvel = yvel;
            this.velocity = new Vector2(xvel, yvel);
            this.color = color;
            this.scolor = color;
            this.scale = scale;
            this.xfric = xfriction;
            this.yfric = yfricition;
        }

        public Particle(TextureSource texture, int ttl, Vector2 position, float xvel, float yvel, float xfriction, float yfricition, Color color, float scale, ParticleForce force)
            : this(texture, ttl, position, xvel, yvel, xfriction, yfricition, color, scale)
        {
            this.force = force;
        }

        public void Draw(SpriteBatch sb)
        {
            if (!Destroyed)
            {
                sb.Draw(texture.Texture, position, texture.Source, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }

        public void Update(GameTime gt)
        {
            if (!Destroyed)
            {
                ttl -= gt.ElapsedGameTime.Milliseconds;

                if (force != null)
                    force.Update(this, gt);

                position += velocity;

                velocity.X *= xfric;
                velocity.Y *= yfric;

                color.R = (byte)(((float)ttl / sttl) * scolor.R);
                color.G = (byte)(((float)ttl / sttl) * scolor.G);
                color.B = (byte)(((float)ttl / sttl) * scolor.B);
            }
        }

        public bool Destroyed { get { return ttl <= 0; } }
        public Vector2 Position { get { return position; } }
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }
    }
}
