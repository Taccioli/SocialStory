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
    public abstract class Component
    {
        private TouchCollection currentTouchState;

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);

        // Passo in rettangolo alla funzione e lei mi dice se sto toccando (con un solo dito)
        // in quella posizione
        public bool TouchManager(Rectangle button)
        {
            currentTouchState = TouchPanel.GetState();
            Rectangle adjustedResButton = new Rectangle((int)(button.X * Const.Proportions.X), (int)(button.Y * Const.Proportions.Y), 
                                                    (int)(button.Width*Const.Proportions.X), (int)(button.Height * Const.Proportions.Y));

            if (currentTouchState.Count == 1)
            {
                  Vector2 Pos = currentTouchState[0].Position;
                  if (Pos.X > adjustedResButton.X && Pos.X < (adjustedResButton.X + adjustedResButton.Width) &&
                          Pos.Y > adjustedResButton.Y && Pos.Y < (adjustedResButton.Y + adjustedResButton.Height))
                      return true;
            }
            return false;
        }
    }
}
