using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames
{
    public class PlayButton : Component
    {
        #region Fields

        private MouseState currentMouse;
        private SpriteFont font;
        private bool isHovering;
        private MouseState previousMouse;
        private Texture2D texture;
        private Texture2D hoverTexture;
        private bool textInside;
        private bool hasHover;
        #endregion

        #region Properties

        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color PenColour { get; set; }
        public Vector2 Position { get; set; }
        public bool isActive;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }
        }

        public string Text { get; set; }

        #endregion

        #region Methods

        // Per buttons con il testo //
        public PlayButton(Texture2D texture, Texture2D hoverTexture, SpriteFont font, bool textInside, bool isActive)
        {
            this.texture = texture;
            this.hoverTexture = hoverTexture;
            this.font = font;
            PenColour = Color.Black;
            this.textInside = textInside;
            this.isActive = isActive;
            this.hasHover = true;
        }
        // Per buttons senza testo //
        public PlayButton(Texture2D texture, Texture2D hoverTexture, bool hasOver, bool isActive)
        {
            this.texture = texture;
            this.hoverTexture = hoverTexture;
            textInside = true;
            this.isActive = isActive;
            this.hasHover = hasOver;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (isHovering)
            {
                if (hasHover)
                    spriteBatch.Draw(hoverTexture, Rectangle, Color.White);
                else
                    spriteBatch.Draw(texture, Rectangle, Color.Gray);
            }
            else
                spriteBatch.Draw(texture, Rectangle, Color.White);

            if (!string.IsNullOrEmpty(Text))
            {
                int x = Rectangle.X + Rectangle.Width / 2;
                int y = (int)((Rectangle.Y + (Rectangle.Height / 2)) - (font.MeasureString(Text).Y / 2));

                if (textInside)
                    spriteBatch.DrawString(font, Text, new Vector2(x - font.MeasureString(Text).X / 2, y), PenColour);
                else
                    DrawString(spriteBatch, font, Text, new Rectangle(x + 40, y, 510, 60));
            }
        }

        public override void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            isHovering = false;

            if (mouseRectangle.Intersects(Rectangle) && isActive)
            {
                isHovering = true;

                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }

        static public void DrawString(SpriteBatch spriteBatch, SpriteFont font, string strToDraw, Rectangle boundaries)
        {
            Vector2 size = font.MeasureString(strToDraw);


            float xScale = (boundaries.Width / size.X);
            float yScale = (boundaries.Height / size.Y);
            if (xScale > 1)
                xScale = 1;
            if (yScale > 1)
                yScale = 1;

            // Taking the smaller scaling value will result in the text always fitting in the boundaires.
            float scale = Math.Min(xScale, yScale);

            // Figure out the location in the boundaries rectangle.
            Vector2 position = new Vector2();
            position.X = boundaries.X;
            position.Y = boundaries.Y;

            // A bunch of settings where we just want to use reasonable defaults.
            float rotation = 0.0f;
            Vector2 spriteOrigin = new Vector2(0, 0);
            float spriteLayer = 0.0f; // all the way in the front
            SpriteEffects spriteEffects = new SpriteEffects();

            // Draw the string to the sprite batch!
            spriteBatch.DrawString(font, strToDraw, position, Color.Black, rotation, spriteOrigin, scale, spriteEffects, spriteLayer);
        }
        #endregion
    }
}