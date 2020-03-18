using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SocialGames_Locale
{
    public class Button : Component
    {
        private string name;
        private Texture2D texture;
        private Color penColour;
        private bool clicked;
        private MouseState currentMouseInput, previousMouseInput;
        private Vector2 position;
        public EventHandler click;
        
        public bool IsHovering()
        {
            if(currentMouseInput.Position.X < position.X + texture.Width &&
                currentMouseInput.Position.X > position.X &&
                currentMouseInput.Position.Y < position.Y + texture.Height &&
                currentMouseInput.Position.Y > position.Y)
            {
                return true;
            }
            return false;
        }

        public Button(string name, Texture2D texture, int positionX, int positionY)
        {
            this.name = name;
            this.texture = texture;
            position.X = positionX;
            position.Y = positionY;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Color colour = Color.White;

            if (IsHovering())
                colour = Color.Gray;

            spriteBatch.Draw(texture, position, colour);
        }

        public override void Update(GameTime gameTime)
        {
            previousMouseInput = currentMouseInput;
            currentMouseInput = Mouse.GetState();

            if(IsHovering()&& previousMouseInput.LeftButton == ButtonState.Released && currentMouseInput.LeftButton == ButtonState.Pressed)
            {
                switch (name)
                {
                    case "START":

                        break;
                    case "selgame":

                        break;
                    case "createavatar":

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
