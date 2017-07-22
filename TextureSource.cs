using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall
{
    public class TextureSource
    {
        private Texture2D texture;
        private Rectangle source;

        public TextureSource(Texture2D texture)
        {
            this.texture = texture;
            this.source = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public TextureSource(Texture2D texture, Rectangle source)
        {
            this.texture = texture;
            this.source = source;
        }

        public Texture2D Texture { get { return texture; } }
        public Rectangle Source { get { return source; } }
    }
}
