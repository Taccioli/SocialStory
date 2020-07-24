﻿using System;
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
    public class SelAvatarButton : Component
    {
        #region FIELDS
        private Game1 game;
        private GraphicsDevice graphicsDevice;
        private ContentManager contentManager;
        private string name;
        private Texture2D texture;
        private TouchCollection currentMouseInput, previousMouseInput;
        private Vector2 position;
        private bool wasHovering, isHovering;
        private Rectangle button;
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

            if (isHovering)
                colour = Color.Gray;

            spriteBatch.Draw(texture, position, colour);
        }

        public override void Update(GameTime gameTime)
        {
            isHovering = IsHovering();
            previousMouseInput = currentMouseInput;
            currentMouseInput = TouchPanel.GetState();

            if (wasHovering && previousMouseInput.Count == 1 && currentMouseInput.Count == 0)
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
            wasHovering = isHovering;
        }
    }
}
