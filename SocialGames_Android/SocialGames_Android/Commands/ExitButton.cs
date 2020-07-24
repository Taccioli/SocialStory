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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace SocialGames_Android
{
    public class ExitButton : Component
    {
        #region Fields

        private Texture2D texture, hoverTexture;
        private TouchCollection currentMouse;
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
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }
        }

        #endregion

        public ExitButton(Texture2D texture, Texture2D hoverTexture)
        {
            this.texture = texture;
            this.hoverTexture = hoverTexture;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!isHovering)
                spriteBatch.Draw(texture, Rectangle, Color.White);
            else
                spriteBatch.Draw(hoverTexture, Rectangle, Color.White);
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
            currentMouse = TouchPanel.GetState();

            if(wasHovering && currentMouse.Count == 0)
                    Click?.Invoke(this, new EventArgs());

            wasHovering = isHovering;
        }
    }
}