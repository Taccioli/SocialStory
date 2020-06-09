using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SocialGames
{
    public class SelAvatarButton : Component
    {
        #region FIELDS
        private Game1 game;
        private GraphicsDevice graphicsDevice;
        private ContentManager contentManager;
        private string name;
        private Texture2D texture;
        private MouseState currentMouseInput, previousMouseInput;
        private Vector2 position;
        #endregion

        public SelAvatarButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager, string name, Texture2D texture, int positionX, int positionY)
        {
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            this.contentManager = contentManager;
            this.name = name;
            this.texture = texture;
            position.X = positionX;
            position.Y = positionY;
        }
        private bool IsHovering()
        {
            if (currentMouseInput.Position.X < position.X + texture.Width &&
                currentMouseInput.Position.X > position.X &&
                currentMouseInput.Position.Y < position.Y + texture.Height &&
                currentMouseInput.Position.Y > position.Y)
            {
                return true;
            }
            return false;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Color colour = Color.White;

            if (IsHovering())
            {
                colour = Color.Gray;
            }

            spriteBatch.Draw(texture, position, colour);
        }

        public override void Update(GameTime gameTime)
        {
            previousMouseInput = currentMouseInput;
            currentMouseInput = Mouse.GetState();

            if (IsHovering() && previousMouseInput.LeftButton == ButtonState.Released && currentMouseInput.LeftButton == ButtonState.Pressed)
            {
                if (GameData.timeSpan < TimeSpan.Zero)
                {
                    switch (name)
                    {
                        case "male1":
                            GameData.avatar = "Boy1";
                            GameData.isMale = true;
                            game.ChangeState(new SelAvatarState(game, graphicsDevice, contentManager));
                            break;
                        case "male2":
                            GameData.avatar = "Boy2";
                            GameData.isMale = true;
                            game.ChangeState(new SelAvatarState(game, graphicsDevice, contentManager));
                            break;
                        case "male3":
                            GameData.avatar = "Boy3";
                            GameData.isMale = true;
                            game.ChangeState(new SelAvatarState(game, graphicsDevice, contentManager));
                            break;
                        case "female1":
                            GameData.avatar = "Girl1";
                            GameData.isMale = false;
                            game.ChangeState(new SelAvatarState(game, graphicsDevice, contentManager));
                            break;
                        case "female2":
                            GameData.avatar = "Girl2";
                            GameData.isMale = false;
                            game.ChangeState(new SelAvatarState(game, graphicsDevice, contentManager));
                            break;
                        case "female3":
                            GameData.avatar = "Girl3";
                            GameData.isMale = false;
                            game.ChangeState(new SelAvatarState(game, graphicsDevice, contentManager));
                            break;
                        case "home":
                            game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
