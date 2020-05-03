using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using Microsoft.Xna.Framework.Input;

namespace SocialGames
{
    public class TimeButton : Component
    {
        #region Fields

        private Texture2D texture, hoverTexture, selectedTexture;
        private MouseState currentMouse;
        private bool isHovering;

        #endregion

        #region Properties

        public event EventHandler Click;
        public bool isSelected { get; set; }
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

        public TimeButton(Texture2D texture, Texture2D hoverTexture, Texture2D selectedTexture)
        {
            this.texture = texture;
            this.hoverTexture = hoverTexture;
            this.selectedTexture = selectedTexture;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if(isSelected)
                spriteBatch.Draw(selectedTexture, Rectangle, Color.White);
            else if (!isHovering)
                spriteBatch.Draw(texture, Rectangle, Color.White);
            else
                spriteBatch.Draw(hoverTexture, Rectangle, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            isHovering = false;

            if (mouseRectangle.Intersects(Rectangle) )
            {
                isHovering = true;

                if (currentMouse.LeftButton == ButtonState.Pressed && !isSelected)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
