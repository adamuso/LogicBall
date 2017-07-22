using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall
{
    public class SpriteManager
    {
        private List<Sprite> sprites;

        public SpriteManager()
        {
            sprites = new List<Sprite>();
        }

        public void Add(Sprite sprite)
        {
            sprites.Add(sprite);
        }

        public void Remove(Sprite sprite)
        {
            sprites.Remove(sprite);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            for (int i = 0; i < sprites.Count; i++)
                sprites[i].Draw(sb);

            sb.End();
        }

        public void Update(GameTime gt)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].Update(gt);

                if (sprites[i].Destroyed)
                {
                    sprites.RemoveAt(i);
                    i--;
                }
            }
        }

        public List<Sprite> Sprites { get { return sprites; } }
    }
}
