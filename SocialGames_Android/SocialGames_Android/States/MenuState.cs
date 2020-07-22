﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SocialGames_Android
{
    public class MenuState : State
    {
        private List<MenuButton> buttons;
        private Texture2D background;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
            : base(game, graphicsDevice, content)
        {
            background = content.Load<Texture2D>("Park");
            // Texture2D avatar = content.Load<Texture2D>("myAvatar");
            Texture2D start = content.Load<Texture2D>("start");
            Texture2D selGame = content.Load<Texture2D>("sel_gioco");
            Texture2D settings = content.Load<Texture2D>("settings");
            Texture2D selAvatar = content.Load<Texture2D>("sel_avatar");
            Texture2D quit = content.Load<Texture2D>("quit");
            Texture2D start_hover = content.Load<Texture2D>("start_hover");
            Texture2D selGame_hover = content.Load<Texture2D>("sel_gioco_hover");
            Texture2D selAvatar_hover = content.Load<Texture2D>("sel_avatar_hover");
            Texture2D settings_hover = content.Load<Texture2D>("settings_hover");
            Texture2D quit_hover = content.Load<Texture2D>("quit_hover");
            MenuButton startBtn = new MenuButton(game, graphicsDevice, contentManager, "start", start, start_hover, Const.LEFTMARGINBTN, Const.TOPMARGINBTN);
            MenuButton selGameBtn = new MenuButton(game, graphicsDevice, contentManager, "selgame", selGame, selGame_hover, Const.LEFTMARGINBTN, (Const.TOPMARGINBTN) + 100);
            MenuButton createAvatarBtn = new MenuButton(game, graphicsDevice, contentManager, "createavatar", selAvatar, selAvatar_hover, Const.LEFTMARGINBTN, (Const.TOPMARGINBTN) + 200);
            MenuButton settingsBtn = new MenuButton(game, graphicsDevice, contentManager, "settings", settings, settings_hover, Const.LEFTMARGINBTN, (Const.TOPMARGINBTN) + 300);
            MenuButton quitBtn = new MenuButton(game, graphicsDevice, contentManager, "quit", quit, quit_hover, Const.LEFTMARGINBTN, (Const.TOPMARGINBTN) + 420);

            buttons = new List<MenuButton>()
            {
                startBtn,
                selGameBtn,
                createAvatarBtn,
                settingsBtn,
                quitBtn
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            foreach (MenuButton button in buttons)
                button.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (MenuButton button in buttons)
                button.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
    }
}
