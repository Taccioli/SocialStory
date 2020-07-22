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

namespace SocialGames_Android
{
    public class Timer
    {
        public float remainingDelay;

        private bool isInfinite = false;
        Game1 game;
        GraphicsDevice graphicsDevice;
        ContentManager contentManager;

        public Timer(float delay, Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            this.contentManager = contentManager;

            if (delay == 0)
                isInfinite = true;
            else
                remainingDelay = delay;
        }

        public void Update(GameTime gameTime)
        {
            if (!isInfinite)
            {
                var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
                remainingDelay -= timer;
                if (remainingDelay <= 0)
                    StopGame();
            }
        }

        private void StopGame()
        {
            game.ChangeState(new EndTimeState(game, graphicsDevice, contentManager));
        }
    }
}
