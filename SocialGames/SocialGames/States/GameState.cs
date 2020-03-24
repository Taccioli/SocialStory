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
using SocialGames.Commands;
using SocialGames.Data;

namespace SocialGames
{
    public class GameState : State
    {
        #region Costanti
        private const int PrimoPrompt = 1;
        private const int SecondoPrompt = 3;
        private const int PrimaRisposta = 2;
        private const int SecondaRisposta = 4;
        private const int Fine = 5;
        #endregion

        #region Fields

        private Texture2D background;
        private SpriteFont textFont;
        private SpriteFont buttonFont;
        private Texture2D prompt;
        private Texture2D story;
        private Texture2D choiceTexture;
        private Texture2D choiceHoverTexture;
        private Texture2D buttonTexture;
        private Texture2D buttonHoverTexture;
        private Texture2D avatar;
        private List<Component> choices;
        private int state;
        private PlayButton firstButton, secondButton, thirdButton;
        private PlayButton capitoButton;
        private string testoPrimaRisposta, testoSecondaRisposta = null;
        private bool correctAnswer;

        // Posizioni delle Texture
        private Vector2 backPos;
        private Vector2 promptPos;
        private Vector2 but1Pos;
        private Vector2 but2Pos;
        private Vector2 but3Pos;
        private Vector2 avatarPos;
        private Vector2 butHoCapPos;
        private Vector2 storyPos;
        private Vector2 storyTextPos;
        private Vector2 questTextPos;
        private Vector2 titleTextPos;

        #endregion

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            this.game = game;
            state = PrimoPrompt;

            choiceTexture = content.Load<Texture2D>("choiceTexture");
            choiceHoverTexture = content.Load<Texture2D>("choiceHoverTexture");
            buttonTexture = content.Load<Texture2D>("buttonTexture");
            // buttonHoverTexture = content.Load<Texture2D>("buttonHoverTexture");
            textFont = content.Load<SpriteFont>("CustomFont");
            buttonFont = content.Load<SpriteFont>("buttonFont");
            background = content.Load<Texture2D>(GameData.background);
            avatar = content.Load<Texture2D>(GameData.avatar);
            prompt = content.Load<Texture2D>("prompt");
            story = content.Load<Texture2D>("story");

            this.Read(GameData.nameFile);

            // Inizializzo i vettori di posizione delle Texture
            backPos = new Vector2(0, 0);
            promptPos = new Vector2((Const.DisplayDim.Y - prompt.Width) / 2 + story.Height + 200, 3 * Const.DisplayDim.X / 4 - prompt.Height / 2);
            storyPos = new Vector2((Const.DisplayDim.Y - story.Width) / 2 - 100, 3 * Const.DisplayDim.X / 4 - story.Height / 2);
            storyTextPos = storyPos + new Vector2(10, 70);
            questTextPos = promptPos + new Vector2(10, 10);
            titleTextPos = storyPos + new Vector2(10, 10);
            but1Pos = promptPos + new Vector2(10, 70);
            but2Pos = promptPos + new Vector2(10, 150);
            but3Pos = promptPos + new Vector2(10, 230);
            butHoCapPos = storyPos + new Vector2(story.Width / 2 - buttonTexture.Width / 2, 280);
            avatarPos = new Vector2(0, 0);

            #region Buttons

            firstButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, false)
            {
                Position = but1Pos,
                Text = GameData.afp,
            };

            firstButton.Click += firstButton_Click;

            secondButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, false)
            {
                Position = but2Pos,
                Text = GameData.bfp,
            };

            secondButton.Click += secondButton_Click;

            thirdButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, false)
            {
                Position = but3Pos,
                Text = GameData.cfp,
            };

            thirdButton.Click += thirdButton_Click;

            choices = new List<Component>()
                    {
                        firstButton,
                        secondButton,
                        thirdButton,
                     };

            capitoButton = new PlayButton(buttonTexture, textFont)
            {
                Position = butHoCapPos,
                Text = "Ho capito!",
            };

            capitoButton.Click += capitoButton_Click;
        }

        private void capitoButton_Click(object sender, EventArgs e)
        {
            if (state == PrimaRisposta)
            {
                if (correctAnswer)
                {
                    state = SecondoPrompt;
                }
                else
                    state = PrimoPrompt;
            }
            else if (state == SecondaRisposta)
            {
                if (correctAnswer)
                {
                    game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                }
                else
                    state = SecondoPrompt;
            }
            correctAnswer = false;
        }

        private void firstButton_Click(object sender, EventArgs e)
        {
            if (state == PrimoPrompt)
            {
                state = PrimaRisposta;
                testoPrimaRisposta = GameData.oafp;
                if (GameData.ans1 == 1)
                {
                    choiceUpdate();
                    correctAnswer = true;
                    Reward();
                }
            }
            else if (state == SecondoPrompt)
            {
                state = SecondaRisposta;
                testoSecondaRisposta = GameData.oasp;
                if (GameData.ans2 == 1)
                {
                    Reward();
                    correctAnswer = true;
                }
            }
        }

        private void secondButton_Click(object sender, EventArgs e)
        {
            if (state == PrimoPrompt)
            {
                state = PrimaRisposta;
                testoPrimaRisposta = GameData.obfp;
                if (GameData.ans1 == 2)
                {
                    choiceUpdate();
                    Reward();
                    correctAnswer = true;
                }
            }
            else if (state == SecondoPrompt)
            {
                state = SecondaRisposta;
                testoSecondaRisposta = GameData.obsp;
                if (GameData.ans2 == 2)
                {
                    Reward();
                    correctAnswer = true;
                }
            }
        }

        private void thirdButton_Click(object sender, EventArgs e)
        {
            if (state == PrimoPrompt)
            {
                state = PrimaRisposta;
                testoPrimaRisposta = GameData.ocfp;
                if (GameData.ans1 == 3)
                {
                    choiceUpdate();
                    Reward();
                    correctAnswer = true;
                }
            }
            else if (state == SecondoPrompt)
            {
                state = SecondaRisposta;
                testoSecondaRisposta = GameData.ocsp;
                if (GameData.ans2 == 3)
                {
                    correctAnswer = true;
                    Reward();
                }
            }
        }

        // Questo metodo mi aggiorna le scritte dei bottoni per il secondo round
        private void choiceUpdate()
        {
            firstButton.Text = GameData.asp;
            secondButton.Text = GameData.bsp;
            thirdButton.Text = GameData.csp;
        }

        #endregion

        private void Reward()
        {
            GameData.rewardAmount += 1;
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, backPos, Color.White);
            spriteBatch.Draw(story, storyPos, Color.White);
            spriteBatch.DrawString(textFont, GameData.title, titleTextPos, Color.Black);

            switch (state)
            {
                case PrimoPrompt:
                    spriteBatch.Draw(prompt, promptPos, Color.White);
                    spriteBatch.DrawString(textFont, GameData.firstQuest, questTextPos, Color.Black);
                    spriteBatch.DrawString(textFont, GameData.firstPrompt, storyTextPos, Color.Black);
                    foreach (var component in choices)
                        component.Draw(gameTime, spriteBatch);
                    break;
                case PrimaRisposta:
                    spriteBatch.DrawString(textFont, testoPrimaRisposta, storyTextPos, Color.Black);
                    capitoButton.Draw(gameTime, spriteBatch);
                    break;
                case SecondoPrompt:
                    spriteBatch.Draw(prompt, promptPos, Color.White);
                    spriteBatch.DrawString(textFont, GameData.secondQuest, questTextPos, Color.Black);
                    spriteBatch.DrawString(textFont, GameData.secondPrompt, storyTextPos, Color.Black);
                    foreach (var component in choices)
                        component.Draw(gameTime, spriteBatch);
                    break;
                case SecondaRisposta:
                    spriteBatch.DrawString(textFont, testoSecondaRisposta, storyTextPos, Color.Black);
                    capitoButton.Draw(gameTime, spriteBatch);
                    break;
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in choices)
                component.Update(gameTime);

            capitoButton.Update(gameTime);
        }

        // Il metodo mi legge il file XML
        public void Read(string nameFile)
        {
            XmlTextReader reader = new XmlTextReader(nameFile);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "title":
                            reader.Read();
                            GameData.title = reader.Value;
                            break;
                        case "fprompt":
                            reader.Read();
                            GameData.firstPrompt = reader.Value;
                            break;
                        case "fquest":
                            reader.Read();
                            GameData.firstQuest = reader.Value;
                            break;
                        case "afp":
                            reader.Read();
                            GameData.afp = reader.Value;
                            break;
                        case "bfp":
                            reader.Read();
                            GameData.bfp = reader.Value;
                            break;
                        case "cfp":
                            reader.Read();
                            GameData.cfp = reader.Value;
                            break;
                        case "oafp":
                            reader.Read();
                            GameData.oafp = reader.Value;
                            break;
                        case "obfp":
                            reader.Read();
                            GameData.obfp = reader.Value;
                            break;
                        case "ocfp":
                            reader.Read();
                            GameData.ocfp = reader.Value;
                            break;
                        case "sprompt":
                            reader.Read();
                            GameData.secondPrompt = reader.Value;
                            break;
                        case "squest":
                            reader.Read();
                            GameData.secondQuest = reader.Value;
                            break;
                        case "asp":
                            reader.Read();
                            GameData.asp = reader.Value;
                            break;
                        case "bsp":
                            reader.Read();
                            GameData.bsp = reader.Value;
                            break;
                        case "csp":
                            reader.Read();
                            GameData.csp = reader.Value;
                            break;
                        case "oasp":
                            reader.Read();
                            GameData.oasp = reader.Value;
                            break;
                        case "obsp":
                            reader.Read();
                            GameData.obsp = reader.Value;
                            break;
                        case "ocsp":
                            reader.Read();
                            GameData.ocsp = reader.Value;
                            break;
                        case "ans1":
                            reader.Read();
                            GameData.ans1 = int.Parse(reader.Value);
                            break;
                        case "ans2":
                            reader.Read();
                            GameData.ans2 = int.Parse(reader.Value);
                            break;
                    }
                }
            }
            GameData.firstPrompt = WrapText(textFont, GameData.firstPrompt, 500);
            GameData.secondPrompt = WrapText(textFont, GameData.secondPrompt, 500);
            GameData.oafp = WrapText(textFont, GameData.oafp, 500);
            GameData.obfp = WrapText(textFont, GameData.obfp, 500);
            GameData.ocfp = WrapText(textFont, GameData.ocfp, 500);
            GameData.oasp = WrapText(textFont, GameData.oasp, 500);
            GameData.obsp = WrapText(textFont, GameData.obsp, 500);
            GameData.ocsp = WrapText(textFont, GameData.ocsp, 500);
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