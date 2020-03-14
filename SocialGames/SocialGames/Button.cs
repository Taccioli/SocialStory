using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SocialGames
{
    public class Button : Game1
    {
        int buttonX, buttonY;
        string Name;
        Texture2D Texture;
        MouseState MouseInput;
        MouseState PreviousInput;

        public int ButtonX
        {
            get
            {
                return buttonX;
            }
        }

        public int ButtonY
        {
            get
            {
                return buttonY;
            }
        }

        public Button(string name, Texture2D texture, int buttonX, int buttonY)
        {
            this.Name = name;
            this.Texture = texture;
            this.buttonX = buttonX;
            this.buttonY = buttonY;
        }

        /**
         * @return true: If a player enters the button with mouse
         */
        public bool IsHovering()
        {
            if (MouseInput.Position.X < buttonX + Texture.Width &&
                    MouseInput.Position.X > buttonX &&
                    MouseInput.Position.Y < buttonY + Texture.Height &&
                    MouseInput.Position.Y > buttonY)
            {
                return true;
            }
            return false;
        }
        
        public void Update(GameTime gameTime)
        {
            if (IsHovering() && PreviousInput.LeftButton == ButtonState.Released && MouseInput.LeftButton == ButtonState.Pressed)
            {
                switch (Name)
                {
                    case "NameOfTheButton": //the name of the button

                        break;
                    default:
                        break;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)ButtonX, (int)ButtonY, Texture.Width, Texture.Height), Color.White);
        }
    }
}
