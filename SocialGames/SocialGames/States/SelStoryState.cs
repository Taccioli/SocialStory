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
        private Texture2D leftArrow, rightArrow;
        private SelStoryButton storyBtn1, storyBtn2, storyBtn3, storyBtn4;
        private SelStoryButton storyBtn5, storyBtn6, storyBtn7, storyBtn8;
        private SelStoryButton leftArrowBtn, rightArrowBtn;
        private List<SelStoryButton> buttons;
        #endregion

        // Costruttore
        public SelStoryState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            //background = content.Load<Texture2D>("Park");
            story1 = content.Load<Texture2D>("SelStory1");
            story2 = content.Load<Texture2D>("SelStory2");
            leftArrow = content.Load<Texture2D>("LeftArrow");
            rightArrow = content.Load<Texture2D>("RightArrow");

            #region Buttons
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
            }
            else if (GameData.page == 2)
            {
                // First line second page
                storyBtn1 = new SelStoryButton(game, graphicsDevice, contentManager, "story9", story2, 120, 259);
                storyBtn2 = new SelStoryButton(game, graphicsDevice, contentManager, "story10", story2, 140 + story1.Width, 259);
                storyBtn3 = new SelStoryButton(game, graphicsDevice, contentManager, "story11", story2, 160 + 2 * (story1.Width), 259);
                storyBtn4 = new SelStoryButton(game, graphicsDevice, contentManager, "story12", story2, 180 + 3 * (story1.Width), 259);
                // Second Line second page
                storyBtn5 = new SelStoryButton(game, graphicsDevice, contentManager, "story13", story2, 120, 359 + story1.Height);
                storyBtn6 = new SelStoryButton(game, graphicsDevice, contentManager, "story14", story2, 140 + story1.Width, 359 + story1.Height);
                storyBtn7 = new SelStoryButton(game, graphicsDevice, contentManager, "story15", story2, 160 + 2 * (story1.Width), 359 + story1.Height);
                storyBtn8 = new SelStoryButton(game, graphicsDevice, contentManager, "story16", story2, 180 + 3 * (story1.Width), 359 + story1.Height);
            }
            // Arrows Button
            leftArrowBtn = new SelStoryButton(game, graphicsDevice, contentManager, "leftArrow", leftArrow, 10, 516);
            rightArrowBtn = new SelStoryButton(game, graphicsDevice, contentManager, "rightArrow", rightArrow, 1840, 516);
            if (GameData.page != Const.TOTALPAGES && GameData.page != 1)
            {
                // List of all buttons
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
                leftArrowBtn,
                rightArrowBtn
            };
            }
            else if(GameData.page == Const.TOTALPAGES)
            {
                // List of all buttons
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
                leftArrowBtn
            };
            }
            else if (GameData.page == 1)
            {
                // List of all buttons
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
                rightArrowBtn
            };
            }
            #endregion
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (SelStoryButton button in buttons)
                button.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (SelStoryButton button in buttons)
                button.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
    }
}
