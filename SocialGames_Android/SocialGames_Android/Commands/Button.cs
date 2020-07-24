using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace SocialGames_Android
{
    public class Button : Component
    {
        private Game1 game;
        private GraphicsDevice graphicsDevice;
        private ContentManager contentManager;
        private string name;
        private Texture2D texture, texture_hover;
        private Color penColour;
        private bool clicked;
        private TouchCollection currentMouseInput;
        private Vector2 position;
        private bool wasHovering;

        public event EventHandler click;

        public bool Clicked { get; private set; }

        public bool IsHovering()
        {
            if (TouchManager(new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height)))
            {
                return true;
            }
            return false;
        }

        public Button(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager, string name, Texture2D texture, Texture2D texture_hover, int positionX, int positionY)
        {
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            this.contentManager = contentManager;
            this.name = name;
            this.texture = texture;
            this.texture_hover = texture_hover;
            position.X = positionX;
            position.Y = positionY;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Color colour = Color.White;
            Texture2D current_texture = texture;

            if (IsHovering())
            {
                //colour = Color.Gray;
                current_texture = texture_hover;
            }

            spriteBatch.Draw(current_texture, position, colour);
        }

        public override void Update(GameTime gameTime)
        {
            currentMouseInput = TouchPanel.GetState();

            if (wasHovering)
            {
                if (currentMouseInput[0].State == TouchLocationState.Released)
                {
                    switch (name)
                    {
                        case "start":
                            game.ChangeState(new GameState(game, graphicsDevice, contentManager));
                            break;
                        case "selgame":
                            game.ChangeState(new GameState(game, graphicsDevice, contentManager));
                            break;
                        case "createavatar":
                            game.ChangeState(new GameState(game, graphicsDevice, contentManager));
                            break;
                        default:
                            break;
                    }
                }
            }
            wasHovering = IsHovering();
        }
    }
}
