using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SocialGames
{
    public class MenuState : State
    {
        private List<Button> buttons;
        private Texture2D background;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
            :base(game, graphicsDevice, content)
        {
            background = content.Load<Texture2D>("Park");
            // Texture2D avatar = content.Load<Texture2D>("myAvatar");
            Texture2D start = content.Load<Texture2D>("start");
            Texture2D selGame = content.Load<Texture2D>("sel_gioco");
            Texture2D createAvatar = content.Load<Texture2D>("crea_avatar");
            Texture2D start_hover = content.Load<Texture2D>("start_hover");
            Texture2D selGame_hover = content.Load<Texture2D>("sel_gioco_hover");
            Texture2D createAvatar_hover = content.Load<Texture2D>("crea_avatar_hover");
            Button startBtn = new Button(game, graphicsDevice, contentManager, "start", start, start_hover , Const.LEFTMARGINBTN, Const.TOPMARGINBTN);
            Button selGameBtn = new Button(game, graphicsDevice, contentManager, "selgame", selGame, selGame_hover, Const.LEFTMARGINBTN, (Const.TOPMARGINBTN) + 100);
            Button createAvatarBtn = new Button(game, graphicsDevice, contentManager, "createavatar", createAvatar, createAvatar_hover, Const.LEFTMARGINBTN, (Const.TOPMARGINBTN) + 200);

            buttons = new List<Button>()
            {
                startBtn,
                selGameBtn,
                createAvatarBtn,
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            foreach (Button button in buttons)
                button.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Button button in buttons)
                button.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
    }
}
