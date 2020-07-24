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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace SocialGames_Android
{
    public class OnOffButton : Component
    {
        #region Fields

        private Texture2D onTexture, offTexture, onHover, offHover, selectedTexture, selectedHover;
        private TouchCollection currentMouse, previousMouse;
        private bool isHovering, wasHovering;
        #endregion

        #region Properties

        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, onTexture.Width, onTexture.Height);
            }
        }

        #endregion

        public OnOffButton(Texture2D textureON, Texture2D textureONHover, Texture2D textureOFF, Texture2D textureOFFHover, bool variable)
        {
            this.onTexture = textureON;
            this.offTexture = textureOFF;
            this.onHover = textureONHover;
            this.offHover = textureOFFHover;
            if(variable)
            {
                selectedTexture = onTexture;
                selectedHover = onHover;
            }
            else
            {
                selectedTexture = offTexture;
                selectedHover = offHover;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (isHovering)
                spriteBatch.Draw(selectedHover, Rectangle, Color.White);
            else
                spriteBatch.Draw(selectedTexture, Rectangle, Color.White);
        }

        private bool IsHovering()
        {
            if (TouchManager(Rectangle))
            {
                return true;
            }
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            isHovering = IsHovering();
            previousMouse = currentMouse;
            currentMouse = TouchPanel.GetState();

            if (wasHovering && previousMouse.Count == 1 && currentMouse.Count == 0)
            {
                if (selectedTexture == onTexture)
                {
                    selectedTexture = offTexture;
                    selectedHover = offHover;
                }
                else
                {
                    selectedTexture = onTexture;
                    selectedHover = onHover;
                }

                Click?.Invoke(this, new EventArgs());
            }

            wasHovering = isHovering;
        }
    }
}
