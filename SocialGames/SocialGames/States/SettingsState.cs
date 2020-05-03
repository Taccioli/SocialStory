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
        private Texture2D timeSelection;
        private Texture2D time10, time20, time30, timeHov10, timeHov20, timeHov30, timeSel10, timeSel20, timeSel30;
        private TimeButton timeB10, timeB20, timeB30;
        private List<TimeButton> timeButtons;

        private Texture2D capital;
        private Texture2D OnText;
        private Texture2D OffText;
        private PlayButton onOff;
        private Texture2D saturation;

        private Vector2 time10Pos;

        public SettingsState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
            : base(game, graphicsDevice, content)
        {
            timeSelection = content.Load<Texture2D>("SettingsState/timer");
            time10 = content.Load<Texture2D>("SettingsState/NonSelected10");
            time20 = content.Load<Texture2D>("SettingsState/NonSelected20");
            time30 = content.Load<Texture2D>("SettingsState/NonSelected30");
            timeHov10 = content.Load<Texture2D>("SettingsState/NonSelectedHover10");
            timeHov20 = content.Load<Texture2D>("SettingsState/NonSelectedHover20");
            timeHov30 = content.Load<Texture2D>("SettingsState/NonSelectedHover30");
            timeSel10 = content.Load<Texture2D>("SettingsState/Selected10");
            timeSel20 = content.Load<Texture2D>("SettingsState/Selected20");
            timeSel30 = content.Load<Texture2D>("SettingsState/Selected30");
            OnText = content.Load<Texture2D>("SettingsState/ON");
            OffText = content.Load<Texture2D>("SettingsState/OFF");

            time10Pos = new Vector2(300,300);

            #region Time Buttons definition

            timeB10 = new TimeButton(time10, timeHov10, timeSel10)
            {
                Position = time10Pos,
                isSelected = true,
            };
            timeB10.Click += timeB10Click;

            timeB20 = new TimeButton(time20, timeHov20, timeSel20)
            {
                Position = time10Pos + new Vector2(200,0),
                isSelected = false,
            };
            timeB20.Click += timeB20Click;

            timeB30 = new TimeButton(time30, timeHov30, timeSel30)
            {
                Position = time10Pos + new Vector2(400, 0),
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
        }

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
            foreach (TimeButton button in timeButtons)
                button.Draw(gameTime, spriteBatch);
        }
        
        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (TimeButton button in timeButtons)
                button.Update(gameTime);
        }
    }
}
