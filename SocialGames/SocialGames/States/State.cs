using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace SocialGames
{
    public abstract class State
    {
        protected Game1 game;
        protected GraphicsDevice graphicsDevice;
        protected ContentManager contentManager;

        public State(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            this.contentManager = content;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void PostUpdate(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}
