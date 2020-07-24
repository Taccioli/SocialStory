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
    public class MenuButton : Component
    {
        #region FIELDS
        private Game1 game;
        private GraphicsDevice graphicsDevice;
        private ContentManager contentManager;
        private string name;
        private Texture2D texture, texture_hover;
        private TouchCollection currentMouseInput;
        private Vector2 position;
        private bool wasHovering;
        private Rectangle button;
        public event EventHandler click;
        private bool isHovering;
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
            button = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        private bool IsHovering()
        {
            if (TouchManager(button))
            {
                return true;
            }
            return false;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Color colour = Color.White;
            Texture2D current_texture = texture;

            if (isHovering)
            {
                //colour = Color.Gray;
                current_texture = texture_hover;
            }

            spriteBatch.Draw(current_texture, position, colour);
        }

        public override void Update(GameTime gameTime)
        {
            isHovering = IsHovering();
            currentMouseInput = TouchPanel.GetState();

            if (wasHovering)
            {
                if (currentMouseInput.Count == 0)
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
                            else if (GameData.nameFile.Equals(""))
                            {
                                game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            }
                            else
                            {
                                if (GameData.isFidanz)
                                {
                                    if (GameData.isMale)
                                        GameData.background = "Fidanzata";
                                    else
                                        GameData.background = "Fidanzato";
                                }
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
                            if (GameData.avatar.Equals(""))
                            {
                                game.ChangeState(new SelAvatarState(game, graphicsDevice, contentManager));
                            }
                            else
                            {
                                game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            }
                            break;
                        case "settings":
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SettingsState(game, graphicsDevice, contentManager));
                            break;
                        case "quit":
                            game.Exit();
                            break;
                        default:
                            break;
                    }
                }
            }
            wasHovering = isHovering;
        }
    }
}