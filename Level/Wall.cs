using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall.Level
{
    public class Wall : Sprite
    {
        public Wall()
        {
            texture = Game.TextureManager.WallTexture;
            drawingArea = new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gt)
        {
            base.Update(gt);

            Game.ParticleManager.GenerateBallFlame(this);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            //base.Draw(sb);
        }
    }
}
