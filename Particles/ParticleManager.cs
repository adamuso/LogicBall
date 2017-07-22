using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall.Particles
{
    public class ParticleManager
    {
        private List<Particle> particles;
        private Queue<Particle> destroyed;

        public ParticleManager()
        {
            particles = new List<Particle>();
            destroyed = new Queue<Particle>();
        }

        public void Add(Particle particle)
        {
            particles.Add(particle);
        }

        public void GenerateExplosion(Vector2 position)
        {
            Random r = Program.Game.Random;
            ParticleForce gravity = new GravityPoint(position, 5f, true);

            for(int i = 0; i < 20; i++)
            {
                particles.Add(new Particle(Program.Game.TextureManager.ParticleTexture, 500 + r.Next(500),
                                           position, 
                                           (float)r.NextDouble() * 3 - (float)r.NextDouble() * 3, 
                                           (float)r.NextDouble() * 3 - (float)r.NextDouble() * 3,
                                           0.95f, 0.95f,
                                           Color.LightBlue, 0.5f + (float)r.NextDouble() * 0.5f));
            }
        }

        public void GenerateBlockBroke(Sprite sprite)
        {
            Texture2D texture = sprite.Texture.Texture;
            Random r = Program.Game.Random;

            float scale = (float)sprite.CollisionArea.Width / texture.Width;
            int ps = 8;
            int w = texture.Width / ps, h = texture.Height / ps;
            ParticleForce gravity = new GravityPoint(new Vector2(sprite.CollisionArea.X + sprite.CollisionArea.Width / 2, sprite.CollisionArea.Y + sprite.CollisionArea.Height / 2), 0.05f, false);

            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                    particles.Add(new Particle(new TextureSource(texture, new Rectangle(x * ps, y * ps, ps, ps)), 500 + r.Next(500),
                                               sprite.Position + new Vector2(x * ps * scale, y * ps * scale), 
                                               (float)r.NextDouble() * 1 - (float)r.NextDouble() * 1, 
                                               (float)r.NextDouble() * 1 - (float)r.NextDouble() * 1,
                                               0.95f, 0.95f,
                                               Color.Gray, scale, gravity));
        }

        public void GenerateBallFlame(Sprite sprite, Color color)
        {
            Texture2D texture = sprite.Texture.Texture;
            Random r = Program.Game.Random;

            float scale = (float)sprite.CollisionArea.Width / texture.Width;
            int ps = 32;
            int w = texture.Width / ps, h = texture.Height / ps;
            ParticleForce gravity = new GravityPoint(new Vector2(sprite.CollisionArea.X + sprite.CollisionArea.Width / 2, sprite.CollisionArea.Y + sprite.CollisionArea.Height / 2), 0.05f, false);

            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                    if ((x + y) % 1 == 0)
                        particles.Add(new Particle(new TextureSource(texture, new Rectangle(x * ps, y * ps, ps, ps)), r.Next(500),
                                                    sprite.Position + new Vector2(x * ps * scale, y * ps * scale), 
                                                    (float)r.NextDouble() * 0.5f - (float)r.NextDouble() * 0.5f, 
                                                    (float)r.NextDouble() * 0.5f - (float)r.NextDouble() * 0.5f,
                                                    0.95f, 0.95f,
                                                    color, scale, gravity));
        }

        public void GenerateBallFlame(Sprite sprite)
        {
            GenerateBallFlame(sprite, new Color(Color.White.ToVector3() * 0.2f));
        }

        public void GenerateBallStop(Sprite sprite, Color color)
        {
            if (sprite is MoveableSprite)
            {
                MoveableSprite movsprite = (MoveableSprite)sprite;
                Texture2D texture = sprite.Texture.Texture;
                Random r = Program.Game.Random;

                float scale = (float)sprite.CollisionArea.Width / texture.Width;
                int ps = 32;
                int w = texture.Width / ps, h = texture.Height / ps;
                ParticleForce gravity = new GravityPoint(new Vector2(sprite.CollisionArea.X + sprite.CollisionArea.Width / 2, sprite.CollisionArea.Y + sprite.CollisionArea.Height / 2), 0.5f, false);

                for (int i = 0; i < 6; i++)
                    for (int y = 0; y < h; y++)
                        for (int x = 0; x < w; x++)
                            if ((x + y) % 1 == 0)
                                particles.Add(new Particle(new TextureSource(texture, new Rectangle(x * ps, y * ps, ps, ps)), r.Next(500),
                                                            sprite.Position + new Vector2(x * ps * scale, y * ps * scale), 
                                                            movsprite.Velocity.X * 20 * ((float)r.NextDouble() - 0.5f), 
                                                            movsprite.Velocity.Y * 20 * ((float)r.NextDouble() - 0.5f),
                                                            0.95f, 0.95f,
                                                            color, scale, gravity));
            }
        }

        public void GenerateBallExplosion(Sprite sprite, Color color)
        {
            Texture2D texture = sprite.Texture.Texture;
            Random r = Program.Game.Random;

            float scale = (float)sprite.CollisionArea.Width / texture.Width;
            int w = texture.Width / 8, h = texture.Height / 8;
            ParticleForce gravity = new GravityPoint(new Vector2(sprite.CollisionArea.X + sprite.CollisionArea.Width / 2, sprite.CollisionArea.Y + sprite.CollisionArea.Height / 2), 1f, false);

            for (int i = 0; i < 5; i++)
                for (int y = 0; y < h; y++)
                    for (int x = 0; x < w; x++)
                        particles.Add(new Particle(new TextureSource(texture, new Rectangle(x * 8, y * 8, 8, 8)), r.Next(500),
                                                   sprite.Position + new Vector2(x * 8 * scale, y * 8 * scale), 
                                                   (float)r.NextDouble() * 20 - (float)r.NextDouble() * 20, 
                                                   (float)r.NextDouble() * 20 - (float)r.NextDouble() * 20,
                                                   0.95f, 0.95f,
                                                   color, scale, gravity));
        }

        public void GenerateBallExplosion(Sprite sprite)
        {
            GenerateBallExplosion(sprite, Color.White);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            for (int i = 0; i < particles.Count; i++)
                particles[i].Draw(sb);
            sb.End();
        }

        public void Update(GameTime gt)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Update(gt);

                if (particles[i].Destroyed)
                    destroyed.Enqueue(particles[i]);
            }

            while (destroyed.Count > 0)
                particles.Remove(destroyed.Dequeue());
        }
    }
}
