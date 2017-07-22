using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall
{
    public abstract class Sprite
    {
        protected TextureSource texture;
        protected Vector2 position;
        protected Color color;
        protected float rotation;
        protected Vector2 origin;
        protected SpriteEffects effects;
        protected Rectangle drawingArea;
        protected bool destroyed;
        protected bool collisionable;
        protected bool solid;

        public Sprite() 
        {
            texture = null;
            position = Vector2.Zero;
            color = Color.White;
            rotation = 0f;
            origin = Vector2.Zero;
            effects = SpriteEffects.None;
            drawingArea = new Rectangle();
            collisionable = true;
            solid = true;
        }

        public virtual void Draw(SpriteBatch sb)
        {
            drawingArea.X = (int)position.X;
            drawingArea.Y = (int)position.Y;

            sb.Draw(texture.Texture, drawingArea, texture.Source, color, rotation, origin, effects, 0f);
        }

        public virtual void Update(GameTime gt)
        {

        }

        public virtual void Collide(Sprite sprite)
        {

        }

        public virtual Rectangle CollisionArea { get { return new Rectangle((int)position.X, (int)position.Y, drawingArea.Width, drawingArea.Height); } }
        public virtual Vector2 Position { get { return position; } set { position = value; } }
        public bool Destroyed { get { return destroyed; } }
        public bool Solid { get { return solid; } }
        public TextureSource Texture { get { return texture; } }
        public bool Collisionable { get { return collisionable; } }
        public LogicBall Game { get { return Program.Game; } }
    }
}
