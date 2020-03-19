using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SocialGames
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;
        Texture2D avatar;
        Texture2D start, selGame, createAvatar;
        Button startBtn, selGameBtn, createAvatarBtn;
        private List<Button> buttons;

        // Build a default font for the game
        public SpriteFont DialogFont { get; private set; }

        // Gestione keyboard
        public KeyboardState KeyState { get; private set; }
        public KeyboardState PreviousKeyState { get; private set; }

        //private DialogBox _dialogBox;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            graphics.PreferredBackBufferHeight = (int)Const.DisplayDim.X;
            graphics.PreferredBackBufferWidth = (int)Const.DisplayDim.Y;
            graphics.IsFullScreen = true;
            IsMouseVisible = true;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            avatar = Content.Load<Texture2D>("myAvatar");
            background = Content.Load<Texture2D>("Park");

            // Inizializzazione font
            DialogFont = Content.Load<SpriteFont>("dialog");
            // Come scrivere una dialogBox
            //_dialogBox = new DialogBox
            //{
            //    Text = "Hello World! Press Enter or Button A to proceed.\n" +
            //           "I will be on the next pane! " +
            //           "And wordwrap will occur, especially if there are some longer words!\n" +
            //           "Monospace fonts work best but you might not want Courier New.\n" +
            //           "In this code sample, after this dialog box finishes, you can press the O key to open a new one."
            //};
            //_dialogBox.Initialize();

            start = Content.Load<Texture2D>("START");
            selGame = Content.Load<Texture2D>("sel_gioco");
            createAvatar = Content.Load<Texture2D>("crea_avatar");
            startBtn = new Button("start", start, Const.LEFTMARGINBTN, Const.TOPMARGINBTN);
            selGameBtn = new Button("selgame", selGame, Const.LEFTMARGINBTN, (Const.TOPMARGINBTN) + 100);
            createAvatarBtn = new Button("createavatar", createAvatar, Const.LEFTMARGINBTN, (Const.TOPMARGINBTN) + 200);
            buttons = new List<Button>()
            {
                startBtn,
                selGameBtn,
                createAvatarBtn,
            };
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // Update DialogBox
            //_dialogBox.Update();

            // Debug key to show opening a new dialog box on demand
            //if (Program.Game.KeyState.IsKeyDown(Keys.O))
            //{
            //    if (!_dialogBox.Active)
            //    {
            //        _dialogBox = new DialogBox { Text = "New dialog box!" };
            //        _dialogBox.Initialize();
            //    }
            //}

            // Update input states
            PreviousKeyState = KeyState;
            KeyState = Keyboard.GetState();

            // TODO: Add your update logic here
            foreach (var button in buttons)
                button.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            // TODO: Add your drawing code here
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            //spriteBatch.Draw(avatar, new Vector2(0, 1080 - 800), Color.White);
            //spriteBatch.Draw(start, new Vector2(Const.LEFTMARGINBTN, Const.TOPMARGINBTN), Color.White);
            //spriteBatch.Draw(selGame, new Vector2(Const.LEFTMARGINBTN, (Const.TOPMARGINBTN) + 100), Color.White);
            //spriteBatch.Draw(createAvatar, new Vector2(Const.LEFTMARGINBTN, (Const.TOPMARGINBTN) + 200), Color.White);
            foreach (var button in buttons)
                button.Draw(gameTime, spriteBatch);

            base.Draw(gameTime);

            // Draw della DialogBox
            //_dialogBox.Draw(spriteBatch);

            spriteBatch.End();

        }
    }
}
