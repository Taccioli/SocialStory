using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SocialGames
{
    public class SelAvatarState : State
    {
        #region Fields
        private Texture2D maleAvatar1, maleAvatar2, maleAvatar3;
        private Texture2D femaleAvatar1, femaleAvatar2, femaleAvatar3;
        private Texture2D maleAvatarSel1, maleAvatarSel2, maleAvatarSel3;
        private Texture2D femaleAvatarSel1, femaleAvatarSel2, femaleAvatarSel3;
        private Texture2D gioca, gioca_hover;
        private Texture2D selStory, selStory_hover;
        private Texture2D home;
        private Texture2D background;
        private SelAvatarButton homeButton;
        private SelAvatarButton maleAvatarButton1, maleAvatarButton2, maleAvatarButton3;
        private SelAvatarButton femaleAvatarButton1, femaleAvatarButton2, femaleAvatarButton3;
        private MenuButton giocaButton;
        private MenuButton selStoryButton;
        private List<SelAvatarButton> buttons;
        #endregion

        public SelAvatarState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            // Texture bottone home
            home = content.Load<Texture2D>("home");
            // Avatar possibili per la selezione
            maleAvatar1 = content.Load<Texture2D>("SelMaschio1");
            maleAvatar2 = content.Load<Texture2D>("SelMaschio2");
            maleAvatar3 = content.Load<Texture2D>("SelMaschio3");
            femaleAvatar1 = content.Load<Texture2D>("SelFemmina1");
            femaleAvatar2 = content.Load<Texture2D>("SelFemmina2");
            femaleAvatar3 = content.Load<Texture2D>("SelFemmina3");
            // Icone avatar post selezione
            maleAvatarSel1 = content.Load<Texture2D>("SelMaschio1_selected");
            maleAvatarSel2 = content.Load<Texture2D>("SelMaschio2_selected");
            maleAvatarSel3 = content.Load<Texture2D>("SelMaschio3_selected");
            femaleAvatarSel1 = content.Load<Texture2D>("SelFemmina1_selected");
            femaleAvatarSel2 = content.Load<Texture2D>("SelFemmina2_selected");
            femaleAvatarSel3 = content.Load<Texture2D>("SelFemmina3_selected");
            // Tasto gioca per iniziare la storia
            gioca = content.Load<Texture2D>("gioca");
            gioca_hover = content.Load<Texture2D>("gioca_hover");
            // Tasto per selezionare la storia, nel caso in cui non sia stata ancora selezionata
            selStory = content.Load<Texture2D>("sel_storia");
            selStory_hover = content.Load<Texture2D>("sel_storia_hover");
            // Background della pagina
            background = content.Load<Texture2D>("SelBackground");

            #region BUTTONS
            // Bottone home 
            homeButton = new SelAvatarButton(game, graphicsDevice, contentManager, "home", home, Const.MARGINHOMEBTN, Const.MARGINHOMEBTN);
            // Bottoni avatar possibili per la selezione
            maleAvatarButton1 = new SelAvatarButton(game, graphicsDevice, contentManager, "male1", maleAvatar1, Const.LEFTMARGINSELAVATAR, Const.TOPMARGINSELAVATAR);
            maleAvatarButton2 = new SelAvatarButton(game, graphicsDevice, contentManager, "male2", maleAvatar2, Const.LEFTMARGINSELAVATAR + 200 + maleAvatar1.Width, Const.TOPMARGINSELAVATAR);
            maleAvatarButton3 = new SelAvatarButton(game, graphicsDevice, contentManager, "male3", maleAvatar3, Const.LEFTMARGINSELAVATAR + 400 + (maleAvatar1.Width + maleAvatar2.Width), Const.TOPMARGINSELAVATAR);
            femaleAvatarButton1 = new SelAvatarButton(game, graphicsDevice, contentManager, "female1", femaleAvatar1, Const.LEFTMARGINSELAVATAR, Const.TOPMARGINSELAVATAR + 100 + maleAvatar1.Height);
            femaleAvatarButton2 = new SelAvatarButton(game, graphicsDevice, contentManager, "female2", femaleAvatar2, Const.LEFTMARGINSELAVATAR + 200 + femaleAvatar1.Width, Const.TOPMARGINSELAVATAR + 100 + maleAvatar2.Height);
            femaleAvatarButton3 = new SelAvatarButton(game, graphicsDevice, contentManager, "female3", femaleAvatar3, Const.LEFTMARGINSELAVATAR + 400 + (femaleAvatar1.Width + femaleAvatar2.Width), Const.TOPMARGINSELAVATAR + 100 + maleAvatar3.Height);
            // Bottone per iniziare il gioco 
            giocaButton = new MenuButton(game, graphicsDevice, contentManager, "start", gioca, gioca_hover, 1670, 969);
            // Bottone per selezionare la storia
            selStoryButton = new MenuButton(game, graphicsDevice, contentManager, "selStory", selStory, selStory_hover, 1670, 1000);

            buttons = new List<SelAvatarButton>
            {
                maleAvatarButton1,
                maleAvatarButton2,
                maleAvatarButton3,
                femaleAvatarButton1,
                femaleAvatarButton2,
                femaleAvatarButton3,
                homeButton
            };

            switch (GameData.avatar)
            {
                case "Boy1":
                    buttons.Remove(maleAvatarButton1);
                    break;
                case "Boy2":
                    buttons.Remove(maleAvatarButton2);
                    break;
                case "Boy3":
                    buttons.Remove(maleAvatarButton3);
                    break;
                case "Girl1":
                    buttons.Remove(femaleAvatarButton1);
                    break;
                case "Girl2":
                    buttons.Remove(femaleAvatarButton2);
                    break;
                case "Girl3":
                    buttons.Remove(femaleAvatarButton3);
                    break;
                default:
                    break;
            }
            #endregion
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 position;

            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            switch (GameData.avatar)
            {
                case "Boy1":
                    position.X = Const.LEFTMARGINSELAVATAR;
                    position.Y = Const.TOPMARGINSELAVATAR;
                    spriteBatch.Draw(maleAvatarSel1, position, Color.White);
                    break;
                case "Boy2":
                    position.X = Const.LEFTMARGINSELAVATAR + 200 + maleAvatarSel1.Width;
                    position.Y = Const.TOPMARGINSELAVATAR;
                    spriteBatch.Draw(maleAvatarSel2, position, Color.White);
                    break;
                case "Boy3":
                    position.X = Const.LEFTMARGINSELAVATAR + 400 + (maleAvatarSel1.Width + maleAvatarSel2.Width);
                    position.Y = Const.TOPMARGINSELAVATAR;
                    spriteBatch.Draw(maleAvatarSel3, position, Color.White);
                    break;
                case "Girl1":
                    position.X = Const.LEFTMARGINSELAVATAR;
                    position.Y = Const.TOPMARGINSELAVATAR + 100 + maleAvatarSel1.Height;
                    spriteBatch.Draw(femaleAvatarSel1, position, Color.White);
                    break;
                case "Girl2":
                    position.X = Const.LEFTMARGINSELAVATAR + 200 + femaleAvatarSel1.Width;
                    position.Y = Const.TOPMARGINSELAVATAR + 100 + maleAvatarSel2.Height;
                    spriteBatch.Draw(femaleAvatarSel2, position, Color.White);
                    break;
                case "Girl3":
                    position.X = Const.LEFTMARGINSELAVATAR + 400 + (femaleAvatarSel1.Width + femaleAvatarSel2.Width);
                    position.Y = Const.TOPMARGINSELAVATAR + 100 + maleAvatarSel3.Height;
                    spriteBatch.Draw(femaleAvatarSel3, position, Color.White);
                    break;
                default:
                    break;
            }

            foreach (SelAvatarButton button in buttons)
                button.Draw(gameTime, spriteBatch);

            if (GameData.isStart && (GameData.nameFile.Equals("")))
                selStoryButton.Draw(gameTime, spriteBatch);
            else if (GameData.isStart && !(GameData.nameFile.Equals("")))
                giocaButton.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (SelAvatarButton button in buttons)
                button.Update(gameTime);

            giocaButton.Update(gameTime);
            selStoryButton.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
    }
}
