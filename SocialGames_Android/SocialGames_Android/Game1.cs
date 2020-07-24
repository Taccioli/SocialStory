using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace SocialGames_Android
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private State currentState;
        private State nextState;

        private Effect effect;
        

        // Build a default font for the game
        public SpriteFont DialogFont { get; private set; }

        // Gestione keyboard
        public KeyboardState KeyState { get; private set; }
        public KeyboardState PreviousKeyState { get; private set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            graphics.ApplyChanges();
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

            Const.scaleMatrix = Matrix.CreateScale(
                        GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 1920f,
                        GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 1080f,
                        1f);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            currentState = new MenuState(this, graphics.GraphicsDevice, Content);
            GameData.timer = new Timer(600, this, graphics.GraphicsDevice, Content);

            effect = Content.Load<Effect>("Desaturation");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
        protected override void Update(GameTime gameTime)
        {
            GameData.timeSpan -= gameTime.ElapsedGameTime;

            // Update input states
            PreviousKeyState = KeyState;
            KeyState = Keyboard.GetState();

            // TODO: Add your update logic here
            if (nextState != null)
            {
                currentState = nextState;
                nextState = null;
            }
            currentState.Update(gameTime);
            currentState.PostUpdate(gameTime);

            GameData.timer.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (GameData.isSaturated)
                spriteBatch.Begin(effect: effect, transformMatrix: Const.scaleMatrix);
            else
                spriteBatch.Begin(transformMatrix: Const.scaleMatrix);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            currentState.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);

            spriteBatch.End();
        }

        public void Quit()
        {
            this.Exit();
        }

        public void ChangeState(State state)
        {
            nextState = state;
        }
    }
}
