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
    public class SelStoryButton : Component
    {
        #region FIELDS
        private Game1 game;
        private GraphicsDevice graphicsDevice;
        private ContentManager contentManager;
        private string name;
        private Texture2D texture;
        private bool clicked;
        private MouseState currentMouseInput, previousMouseInput;
        private Vector2 position;
        #endregion

        public SelStoryButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager, string name, Texture2D texture, int positionX, int positionY)
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
                switch (name)
                {
                    case "story1":
                        game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                        break;
                    case "story2":
                        game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                        break;
                    case "story3":
                        game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                        break;
                    case "story4":
                        game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                        break;
                    case "story5":
                        game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                        break;
                    case "story6":
                        game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                        break;
                    case "story7":
                        game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                        break;
                    case "story8":
                        game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                        break;
                    case "leftArrow":
                        if (GameData.page > 1)
                            GameData.page -= 1;
                        game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                        break;
                    case "rightArrow":
                        if (GameData.page < Const.TOTALPAGES)
                            GameData.page += 1;
                        game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
