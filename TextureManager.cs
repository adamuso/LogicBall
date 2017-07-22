using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall
{
    public class TextureManager
    {
        private LogicBall game;
        
        private TextureSource ballTexture;
        private TextureSource wallTexture;
        private TextureSource crackedWallTexture;
        private TextureSource particleTexture;
        private TextureSource backgroundTexture;

        public TextureManager(LogicBall game)
        {
            this.game = game;
        }

        public void LoadContent()
        {
            ballTexture = new TextureSource(game.Content.Load<Texture2D>("Ball.png"));
            wallTexture = new TextureSource(game.Content.Load<Texture2D>("Brick.png"));
            particleTexture = new TextureSource(game.Content.Load<Texture2D>("particle.png"));
            crackedWallTexture = new TextureSource(game.Content.Load<Texture2D>("CrackedBrick.png"));
            backgroundTexture = new TextureSource(game.Content.Load<Texture2D>("galaxy.jpg"));
        }

        public TextureSource BallTexture { get { return ballTexture; } }
        public TextureSource WallTexture { get { return wallTexture; } }
        public TextureSource ParticleTexture { get { return particleTexture; } }
        public TextureSource CrackedWallTexture { get { return crackedWallTexture; } }
        public TextureSource BackgroundTexture { get { return backgroundTexture; } }
    }
}
