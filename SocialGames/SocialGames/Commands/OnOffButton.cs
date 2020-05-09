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
    public class OnOffButton : Component
    {
        #region Fields

        private Texture2D onTexture, offTexture, selectedTexture;
        private MouseState currentMouse, previousMouse;
        private bool isHovering;
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

        public OnOffButton(Texture2D texture, Texture2D hoverTexture, bool variable)
        {
            this.onTexture = texture;
            this.offTexture = hoverTexture;
            if (variable)
                selectedTexture = onTexture;
            else
                selectedTexture = offTexture;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (isHovering)
                spriteBatch.Draw(selectedTexture, Rectangle, Color.Gray);
            else
                spriteBatch.Draw(selectedTexture, Rectangle, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();
            isHovering = false;

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);
            if (mouseRectangle.Intersects(Rectangle))
            {
                isHovering = true;

                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    if (selectedTexture == onTexture)
                        selectedTexture = offTexture;
                    else
                        selectedTexture = onTexture;

                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
