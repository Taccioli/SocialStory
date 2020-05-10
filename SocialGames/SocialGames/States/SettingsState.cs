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
    public class SettingsState : State
    {
        private Texture2D time10, time20, time30, timeHov10, timeHov20,
                            timeHov30, timeSel10, timeSel20, timeSel30;
        private Texture2D onText, offText, onHoverText, offHoverText;
        private Texture2D back, backHover, background;
        private SpriteFont font,titleFont;

        private TimeButton timeB10, timeB20, timeB30;
        private List<TimeButton> timeButtons;
        private OnOffButton capitalOnOff;
        private OnOffButton saturationOnOff;
        private PlayButton backBut;

        private Vector2 time10ButPos;
        private Vector2 capitalButPos, saturationButPos;
        private Vector2 capitalPos, saturationPos, timePos, settingsPos;
        private Vector2 backPos, backgroundPos;

        private string timeLabel, capitalLabel, saturationLabel, settings;

        public SettingsState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
            : base(game, graphicsDevice, content)
        {
            #region Textures
            //timeSelection = content.Load<Texture2D>("SettingsState/timer");
            time10 = content.Load<Texture2D>("SettingsState/NonSelected10");
            time20 = content.Load<Texture2D>("SettingsState/NonSelected20");
            time30 = content.Load<Texture2D>("SettingsState/NonSelected30");
            timeHov10 = content.Load<Texture2D>("SettingsState/NonSelectedHover10");
            timeHov20 = content.Load<Texture2D>("SettingsState/NonSelectedHover20");
            timeHov30 = content.Load<Texture2D>("SettingsState/NonSelectedHover30");
            timeSel10 = content.Load<Texture2D>("SettingsState/Selected10");
            timeSel20 = content.Load<Texture2D>("SettingsState/Selected20");
            timeSel30 = content.Load<Texture2D>("SettingsState/Selected30");
            onText = content.Load<Texture2D>("SettingsState/ON");
            offText = content.Load<Texture2D>("SettingsState/OFF");
            onHoverText = content.Load<Texture2D>("SettingsState/ONHover");
            offHoverText = content.Load<Texture2D>("SettingsState/OFFHover");
            back = content.Load<Texture2D>("SettingsState/Indietro");
            backHover = content.Load<Texture2D>("SettingsState/IndietroHover");
            background = content.Load<Texture2D>("SettingsState/Background");
            #endregion

            font = content.Load<SpriteFont>("SettingsState/Font");
            titleFont = content.Load<SpriteFont>("SettingsState/Font");
            timeLabel = "Tempo di gioco:";
            capitalLabel = "Scritte maiuscole";
            saturationLabel = "Colori tenui";
            settings = "IMPOSTAZIONI DI GIOCO";

            #region Vectors

            settingsPos = new Vector2(Const.DisplayDim.Y / 20, Const.DisplayDim.X / 20);
            timePos = settingsPos + new Vector2(0, Const.DisplayDim.X / 10);
            time10ButPos = timePos + new Vector2(100, Const.DisplayDim.X / 8);
            capitalPos = time10ButPos + new Vector2(-100, Const.DisplayDim.X / 5);
            capitalButPos = capitalPos + new Vector2(600,-20);
            saturationPos = capitalPos + new Vector2(0, Const.DisplayDim.X / 8);
            saturationButPos = saturationPos + new Vector2(600, -10);
            backPos = saturationPos + new Vector2(100,Const.DisplayDim.X / 8);
            backgroundPos = new Vector2(0, 0);
            #endregion

            #region Time Buttons definition

            timeB10 = new TimeButton(time10, timeHov10, timeSel10)
            {
                Position = time10ButPos,
                isSelected = true,
            };
            timeB10.Click += timeB10Click;

            timeB20 = new TimeButton(time20, timeHov20, timeSel20)
            {
                Position = time10ButPos + new Vector2(200,0),
                isSelected = false,
            };
            timeB20.Click += timeB20Click;

            timeB30 = new TimeButton(time30, timeHov30, timeSel30)
            {
                Position = time10ButPos + new Vector2(400, 0),
                isSelected = false
            };
            timeB30.Click += timeB30Click;

            timeButtons = new List<TimeButton>()
            {
                        timeB10,
                        timeB20,
                        timeB30
            };

            #endregion

            #region On/Off Buttons definition

            capitalOnOff = new OnOffButton(onText, onHoverText, offText, offHoverText, GameData.isCapital)
            {
                Position = capitalButPos
            };
            capitalOnOff.Click += capitalOnOffClick;

            saturationOnOff = new OnOffButton(onText, onHoverText, offText, offHoverText, GameData.isSaturated)
            {
                Position = saturationButPos
            };
            saturationOnOff.Click += saturationOnOffClick;

            #endregion

            backBut = new PlayButton(back, backHover, true, true)
            {
                Position = backPos
            };
            backBut.Click += backButClick;
        }

        private void backButClick(object sender, EventArgs e)
        {
            game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
        }

        #region OnOff Button Methods

        private void saturationOnOffClick(object sender, EventArgs e)
        {
            GameData.isSaturated = !GameData.isSaturated;
        }

        private void capitalOnOffClick(object sender, EventArgs e)
        {
            GameData.isCapital = !GameData.isCapital;
        }

        #endregion

        #region Time Buttons methods
        private void timeB10Click(object sender, EventArgs e)
        {
            foreach (TimeButton button in timeButtons)
                button.isSelected = false;
            timeB10.isSelected = true;
            GameData.timer.remainingDelay = 600;
        }

        private void timeB20Click(object sender, EventArgs e)
        {
            foreach (TimeButton button in timeButtons)
                button.isSelected = false;
            timeB20.isSelected = true;
            GameData.timer.remainingDelay = 1200;
        }

        private void timeB30Click(object sender, EventArgs e)
        {
            foreach (TimeButton button in timeButtons)
                button.isSelected = false;
            timeB30.isSelected = true;
            GameData.timer.remainingDelay = 1800;
        }
#endregion

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(background, backgroundPos, Color.White);

            foreach (TimeButton button in timeButtons)
                button.Draw(gameTime, spriteBatch);
            saturationOnOff.Draw(gameTime, spriteBatch);

            capitalOnOff.Draw(gameTime, spriteBatch);

            backBut.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(font, settings, settingsPos, Color.Black);
            spriteBatch.DrawString(font, capitalLabel, capitalPos, Color.Black);
            spriteBatch.DrawString(font, timeLabel, timePos, Color.Black);
            spriteBatch.DrawString(font, saturationLabel, saturationPos, Color.Black);

            spriteBatch.End();
        }
        
        public override void PostUpdate(GameTime gameTime){}

        public override void Update(GameTime gameTime)
        {
            foreach (TimeButton button in timeButtons)
                button.Update(gameTime);

            saturationOnOff.Update(gameTime);
            capitalOnOff.Update(gameTime);

            backBut.Update(gameTime);
        }
    }
}
