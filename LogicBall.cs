#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using LogicBall.Particles;
using LogicBall.Level;
#endregion

namespace LogicBall
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class LogicBall : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private TextureManager textureManager;
        private SpriteManager spriteManager;
        private CollisionManager collisionManager;
        private ParticleManager particleManager;
        private Random random;       

        public LogicBall()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            random = new Random();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            Ball b = new Ball();
            spriteManager.Add(b);
            MovingWall w = new MovingWall();

            for (int i = 0; i < 50; i++)
            {
                w.Position = new Vector2((float)random.NextDouble() * 800f, (float)random.NextDouble() * 600f);
                spriteManager.Add(w);

                if (CollisionManager.Find(w) != null)
                    spriteManager.Remove(w);

                w = new MovingWall();
            }

            BrokenWall e = new BrokenWall();

            for (int i = 0; i < 50; i++)
            {
                e.Position = new Vector2((float)random.NextDouble() * 800f, (float)random.NextDouble() * 600f);
                spriteManager.Add(e);

                if (CollisionManager.Find(e) != null)
                    spriteManager.Remove(e);

                e = new BrokenWall();
            }

            Wall ww = new Wall();

            for (int i = 0; i < 50; i++)
            {
                ww.Position = new Vector2((float)random.NextDouble() * 800f, (float)random.NextDouble() * 600f);
                spriteManager.Add(ww);

                if (CollisionManager.Find(ww) != null)
                    spriteManager.Remove(ww);

                ww = new Wall();
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            textureManager = new TextureManager(this);
            spriteManager = new SpriteManager();
            collisionManager = new CollisionManager(spriteManager);
            particleManager = new ParticleManager();

            textureManager.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gt)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            spriteManager.Update(gt);
            particleManager.Update(gt);
            
            base.Update(gt);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(textureManager.BackgroundTexture.Texture, GraphicsDevice.Viewport.Bounds, new Color(60, 60, 60));
            spriteBatch.End();

            // TODO: Add your drawing code here
            particleManager.Draw(spriteBatch);
            spriteManager.Draw(spriteBatch);


            base.Draw(gameTime);
        }

        public TextureManager TextureManager { get { return textureManager; } }
        public SpriteManager SpriteManager { get { return spriteManager; } }
        public CollisionManager CollisionManager { get { return collisionManager; } }
        public ParticleManager ParticleManager { get { return particleManager; } }
        public Random Random { get { return random; } }
    }
}
