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
        #region Fields
        private Game1 game;
        private GraphicsDevice graphicsDevice;
        private ContentManager contentManager;
        private string name;
        private Texture2D texture;
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
                if(GameData.timeSpan < TimeSpan.Zero)
                {
                    switch (name)
                    {
                        case "story1":
                            GameData.story = "story1";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story2":
                            GameData.story = "story2";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story3":
                            GameData.story = "story3";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story4":
                            GameData.story = "story4";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story5":
                            GameData.story = "story5";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story6":
                            GameData.story = "story6";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story7":
                            GameData.story = "story7";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story8":
                            GameData.story = "story8";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story9":
                            GameData.story = "story9";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story10":
                            GameData.story = "story10";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story11":
                            GameData.story = "story11";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story12":
                            GameData.story = "story12";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story13":
                            GameData.story = "story13";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story14":
                            GameData.story = "story14";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story15":
                            GameData.story = "story15";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "story16":
                            GameData.story = "story16";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "leftArrow":
                            if (GameData.page > 1)
                                GameData.page -= 1;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            GameData.timeSpan = Const.TIMER;
                            break;
                        case "rightArrow":
                            if (GameData.page < Const.TOTALPAGES)
                                GameData.page += 1;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            GameData.timeSpan = Const.TIMER;
                            break;
                        case "home":
                            game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                            GameData.timeSpan = Const.TIMER;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
