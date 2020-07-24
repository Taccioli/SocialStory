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

namespace SocialGames_Android
{
    class EndGameState : State
    {
        private Vector2 backPos, promptPos;
        private Vector2 menuButPos, changeStoryButPos;
        private Vector2 textPromptPos;
        private Texture2D background, story;
        private Texture2D menuButTex, menuButHoverTex, changeStoryButTex, changeStoryButHoverTex;
        private ExitButton menuButton, changeStoryButton;
        private SpriteFont textFont;
        private string message;

        public EndGameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
            : base(game, graphicsDevice, content)
        {
            this.game = game;

            background = content.Load<Texture2D>("CompletedBackground/" + GameData.background);
            story = content.Load<Texture2D>("EndGameState/StoriaCompletata");
            menuButTex = content.Load<Texture2D>("EndGameState/MenuButton");
            menuButHoverTex = content.Load<Texture2D>("EndGameState/MenuButtonHover");
            changeStoryButTex = content.Load<Texture2D>("EndGameState/ContinuaButton");
            changeStoryButHoverTex = content.Load<Texture2D>("EndGameState/ContinuaButtonHover");
            textFont = content.Load<SpriteFont>("GameState/CustomFont");

            backPos = new Vector2(0, 0);
            promptPos = Const.CenterScreen - new Vector2(story.Width / 2, story.Height / 2);
            menuButPos = promptPos + new Vector2(-5, 210);
            changeStoryButPos = promptPos + new Vector2(story.Width - changeStoryButTex.Width + 10, 210);
            textPromptPos = promptPos + new Vector2(15, 75);

            message = "Bravo! Hai completato questa storia! Vuoi scegliere " +
                        "un'altra storia da giocare o tornare al menù principale?";

            if (GameData.isCapital)
                message = WrapText(textFont, message.ToUpper(), story.Width - 10);
            else
                message = WrapText(textFont, message, story.Width - 10);

            menuButton = new ExitButton(menuButTex, menuButHoverTex)
            {
                Position = menuButPos
            };
            menuButton.Click += menuButtonClick;

            changeStoryButton = new ExitButton(changeStoryButTex, changeStoryButHoverTex)
            {
                Position = changeStoryButPos
            };
            changeStoryButton.Click += changeStoryButtonClick;
        }

        private void menuButtonClick(object sender, EventArgs e)
        {
            game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
        }

        private void changeStoryButtonClick(object sender, EventArgs e)
        {
            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, backPos, Color.White);
            spriteBatch.Draw(story, promptPos, Color.White);
            menuButton.Draw(gameTime, spriteBatch);
            changeStoryButton.Draw(gameTime, spriteBatch);

            spriteBatch.End();
            spriteBatch.Begin(transformMatrix: Const.scaleMatrix);

            spriteBatch.DrawString(textFont, message, textPromptPos, Color.Black);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            menuButton.Update(gameTime);
            changeStoryButton.Update(gameTime);
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
