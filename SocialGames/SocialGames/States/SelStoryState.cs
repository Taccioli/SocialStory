using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SocialGames
{
    public class SelStoryState : State
    {
        #region Fields
        //private Texture2D background;
        private Texture2D story1, story2;
        private Texture2D storySel1, storySel2;
        private Texture2D leftArrow, rightArrow;
        private Texture2D gioca, gioca_hover;
        private Texture2D home;
        private SelStoryButton storyBtn1, storyBtn2, storyBtn3, storyBtn4;
        private SelStoryButton storyBtn5, storyBtn6, storyBtn7, storyBtn8;
        private SelStoryButton storyBtn9, storyBtn10, storyBtn11, storyBtn12;
        private SelStoryButton storyBtn13, storyBtn14, storyBtn15, storyBtn16;
        private SelStoryButton leftArrowBtn, rightArrowBtn;
        private SelStoryButton homeButton;
        private MenuButton giocaButton;
        private List<SelStoryButton> buttons;
        #endregion

        // Costruttore
        public SelStoryState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            //background = content.Load<Texture2D>("Park");
            story1 = content.Load<Texture2D>("SelStory1");
            story2 = content.Load<Texture2D>("SelStory2");
            storySel1 = content.Load<Texture2D>("SelStory1_selected");
            storySel2 = content.Load<Texture2D>("SelStory2_selected");
            leftArrow = content.Load<Texture2D>("LeftArrow");
            rightArrow = content.Load<Texture2D>("RightArrow");
            home = content.Load<Texture2D>("home");
            // Tasto gioca per iniziare la storia
            gioca = content.Load<Texture2D>("gioca");
            gioca_hover = content.Load<Texture2D>("gioca_hover");

            #region Buttons
            // Arrow Buttons
            leftArrowBtn = new SelStoryButton(game, graphicsDevice, contentManager, "leftArrow", leftArrow, 10, 516);
            rightArrowBtn = new SelStoryButton(game, graphicsDevice, contentManager, "rightArrow", rightArrow, 1840, 516);
            // Home Button
            homeButton = new SelStoryButton(game, graphicsDevice, contentManager, "home", home, Const.MARGINHOMEBTN, Const.MARGINHOMEBTN);
            // Play Button 
            giocaButton = new MenuButton(game, graphicsDevice, contentManager, "start", gioca, gioca_hover, 1670, 969);

            if (GameData.page == 1)
            {
                // First line first page
                storyBtn1 = new SelStoryButton(game, graphicsDevice, contentManager, "story1", story1, 120, 259);
                storyBtn2 = new SelStoryButton(game, graphicsDevice, contentManager, "story2", story1, 140 + story1.Width, 259);
                storyBtn3 = new SelStoryButton(game, graphicsDevice, contentManager, "story3", story1, 160 + 2 * (story1.Width), 259);
                storyBtn4 = new SelStoryButton(game, graphicsDevice, contentManager, "story4", story1, 180 + 3 * (story1.Width), 259);
                // Second Line first page
                storyBtn5 = new SelStoryButton(game, graphicsDevice, contentManager, "story5", story1, 120, 359 + story1.Height);
                storyBtn6 = new SelStoryButton(game, graphicsDevice, contentManager, "story6", story1, 140 + story1.Width, 359 + story1.Height);
                storyBtn7 = new SelStoryButton(game, graphicsDevice, contentManager, "story7", story1, 160 + 2 * (story1.Width), 359 + story1.Height);
                storyBtn8 = new SelStoryButton(game, graphicsDevice, contentManager, "story8", story1, 180 + 3 * (story1.Width), 359 + story1.Height);
                // List of all story buttons
                buttons = new List<SelStoryButton>
            {
                storyBtn1,
                storyBtn2,
                storyBtn3,
                storyBtn4,
                storyBtn5,
                storyBtn6,
                storyBtn7,
                storyBtn8,
                homeButton
            };
            }
            else if (GameData.page == 2)
            {
                // First line second page
                storyBtn9 = new SelStoryButton(game, graphicsDevice, contentManager, "story9", story2, 120, 259);
                storyBtn10 = new SelStoryButton(game, graphicsDevice, contentManager, "story10", story2, 140 + story1.Width, 259);
                storyBtn11 = new SelStoryButton(game, graphicsDevice, contentManager, "story11", story2, 160 + 2 * (story1.Width), 259);
                storyBtn12 = new SelStoryButton(game, graphicsDevice, contentManager, "story12", story2, 180 + 3 * (story1.Width), 259);
                // Second Line second page
                storyBtn13 = new SelStoryButton(game, graphicsDevice, contentManager, "story13", story2, 120, 359 + story1.Height);
                storyBtn14 = new SelStoryButton(game, graphicsDevice, contentManager, "story14", story2, 140 + story1.Width, 359 + story1.Height);
                storyBtn15 = new SelStoryButton(game, graphicsDevice, contentManager, "story15", story2, 160 + 2 * (story1.Width), 359 + story1.Height);
                storyBtn16 = new SelStoryButton(game, graphicsDevice, contentManager, "story16", story2, 180 + 3 * (story1.Width), 359 + story1.Height);
                // List of all story buttons
                buttons = new List<SelStoryButton>
            {
                storyBtn9,
                storyBtn10,
                storyBtn11,
                storyBtn12,
                storyBtn13,
                storyBtn14,
                storyBtn15,
                storyBtn16,
                homeButton
            };
            }

            if (GameData.page == Const.TOTALPAGES)
            {
                // Add Left Arrow Button to buttons
                buttons.Add(leftArrowBtn);
            }
            else if (GameData.page == 1)
            {
                // Add Right Arrow Button to buttons
                buttons.Add(rightArrowBtn);
            }
            #endregion
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 position;

            spriteBatch.Begin();

            switch (GameData.story)
            {
                case "story1":
                    buttons.Remove(storyBtn1);
                    position.X = 120;
                    position.Y = 259;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "story2":
                    buttons.Remove(storyBtn2);
                    position.X = 140 + story1.Width;
                    position.Y = 259;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "story3":
                    buttons.Remove(storyBtn3);
                    position.X = 160 + 2 * (story1.Width);
                    position.Y = 259;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "story4":
                    buttons.Remove(storyBtn4);
                    position.X = 180 + 3 * (story1.Width);
                    position.Y = 259;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "story5":
                    buttons.Remove(storyBtn5);
                    position.X = 120;
                    position.Y = 359 + story1.Height;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "story6":
                    buttons.Remove(storyBtn6);
                    position.X = 140 + story1.Width;
                    position.Y = 359 + story1.Height;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "story7":
                    buttons.Remove(storyBtn7);
                    position.X = 160 + 2 * (story1.Width);
                    position.Y = 359 + story1.Height;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "story8":
                    buttons.Remove(storyBtn8);
                    position.X = 180 + 3 * (story1.Width);
                    position.Y = 359 + story1.Height;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "story9":
                    buttons.Remove(storyBtn9);
                    position.X = 120;
                    position.Y = 259;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                case "story10":
                    buttons.Remove(storyBtn10);
                    position.X = 140 + story1.Width;
                    position.Y = 259;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                case "story11":
                    buttons.Remove(storyBtn11);
                    position.X = 160 + 2 * (story1.Width);
                    position.Y = 259;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                case "story12":
                    buttons.Remove(storyBtn12);
                    position.X = 180 + 3 * (story1.Width);
                    position.Y = 259;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                case "story13":
                    buttons.Remove(storyBtn13);
                    position.X = 120;
                    position.Y = 359 + story1.Height;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                case "story14":
                    buttons.Remove(storyBtn14);
                    position.X = 140 + story1.Width;
                    position.Y = 359 + story1.Height;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                case "story15":
                    buttons.Remove(storyBtn15);
                    position.X = 160 + 2 * (story1.Width);
                    position.Y = 359 + story1.Height;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                case "story16":
                    buttons.Remove(storyBtn16);
                    position.X = 180 + 3 * (story1.Width);
                    position.Y = 359 + story1.Height;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                default:
                    break;
            }

            foreach (SelStoryButton button in buttons)
                button.Draw(gameTime, spriteBatch);

            if (GameData.isStart)
                giocaButton.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (SelStoryButton button in buttons)
                button.Update(gameTime);

            giocaButton.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
    }
}
