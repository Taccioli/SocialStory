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
    public class EndTimeState : State
    {
        private Vector2 backPos, promptPos;
        private Vector2 exitButPos;
        private Vector2 textPromptPos, titlePromptPos;
        private Texture2D background, story;
        private Texture2D buttonTexture, buttonHoverTexture;
        private ExitButton exitButton;
        private SpriteFont textFont;
        private string message, title;

        public EndTimeState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
            : base(game, graphicsDevice, content)
        {
            this.game = game;

            background = content.Load<Texture2D>(GameData.background);
            story = content.Load<Texture2D>("GameState/story");
            buttonTexture = content.Load<Texture2D>("EndTimeState/buttonTexture");
            buttonHoverTexture = content.Load<Texture2D>("EndTimeState/buttonHoverTexture");
            textFont = content.Load<SpriteFont>("GameState/CustomFont");

            backPos = new Vector2(0, 0);
            promptPos = Const.CenterScreen - new Vector2(story.Width / 2, story.Height / 2);
            exitButPos = promptPos + new Vector2(story.Width / 2 - buttonTexture.Width / 2, 280);
            textPromptPos = promptPos + new Vector2(10, 70);
            titlePromptPos = promptPos + new Vector2(10, 10);
            message = "Sembra che sia finito il tempo per giocare! Sei stato molto bravo: hai vinto ben " + 
                            GameData.rewardAmount.ToString() + " monete, ora è il momento di riposarsi un po'.";

            if(GameData.isCapital)
            {
                message = WrapText(textFont, message.ToUpper(), story.Width - 10);
                title = "TEMPO SCADUTO";
            }
            else
            {
                message = WrapText(textFont, message.ToUpper(), story.Width - 10); ;
                title = "Tempo scaduto!";
            }

            exitButton = new ExitButton(buttonTexture, buttonHoverTexture)
            {
                Position = exitButPos
            };
            exitButton.Click += exitButtonClick;
        }

        private void exitButtonClick(object sender, EventArgs e)
        {
            game.Quit();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(background, backPos, Color.White);
            spriteBatch.Draw(story, promptPos, Color.White);
            exitButton.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(textFont, message, textPromptPos, Color.Black);
            spriteBatch.DrawString(textFont, title, titlePromptPos, Color.Black);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            exitButton.Update(gameTime);
        }

        public string WrapText(SpriteFont spriteFont, string text, float maxLineWidth)
        {
            string[] words = text.Split(' ');
            StringBuilder sb = new StringBuilder();
            float lineWidth = 0f;
            float spaceWidth = spriteFont.MeasureString(" ").X;

            foreach (string word in words)
            {
                Vector2 size = spriteFont.MeasureString(word);

                if (lineWidth + size.X < maxLineWidth)
                {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    sb.Append("\n" + word + " ");
                    lineWidth = size.X + spaceWidth;
                }
            }

            return sb.ToString();
        }
    }
}
