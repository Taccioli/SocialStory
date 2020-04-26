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
    public class MenuButton : Component
    {
        #region FIELDS
        private Game1 game;
        private GraphicsDevice graphicsDevice;
        private ContentManager contentManager;
        private string name;
        private Texture2D texture, texture_hover;
        private MouseState currentMouseInput, previousMouseInput;
        private Vector2 position;
        public event EventHandler click;
        #endregion

        public MenuButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager, string name, Texture2D texture, Texture2D texture_hover, int positionX, int positionY)
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
            previousMouseInput = currentMouseInput;
            currentMouseInput = Microsoft.Xna.Framework.Input.Mouse.GetState();

            if (IsHovering() && previousMouseInput.LeftButton == ButtonState.Released && currentMouseInput.LeftButton == ButtonState.Pressed)
            {
                if (GameData.timeSpan < TimeSpan.Zero)
                {
                    switch (name)
                    {
                        case "start":
                            GameData.timeSpan = Const.TIMER;
                            GameData.isStart = true;
                            if (GameData.avatar.Equals(""))
                            {
                                game.ChangeState(new SelAvatarState(game, graphicsDevice, contentManager));
                            }
                            else if (GameData.story.Equals(""))
                            {
                                game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            }
                            else
                            {
                                game.ChangeState(new GameState(game, graphicsDevice, contentManager));
                            }
                            break;
                        case "selgame":
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "createavatar":
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelAvatarState(game, graphicsDevice, contentManager));
                            break;
                        case "story1":
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                            break;
                        case "selStory":
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
