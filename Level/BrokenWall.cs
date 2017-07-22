using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall.Level
{
    public class BrokenWall : Sprite
    {
        public BrokenWall()
        {
            texture = Game.TextureManager.CrackedWallTexture;
            drawingArea = new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32);
        }

        public override void Collide(Sprite sprite)
        {
            base.Collide(sprite);

            if(sprite is Ball && !destroyed)
            {
                Game.ParticleManager.GenerateBlockBroke(this);
                destroyed = true;
            }
        }

        public override void Update(GameTime gt)
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
