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

        // private Texture2D buttonHoverTexture;
        private Texture2D avatar;
        private Texture2D angryAvatar, illAvatar, cryingAvatar, happyAvatar, normalAvatar;
        private List<Component> firstButtons, secondButtons, otherButtons;
        private int state;
        private PlayButton firstAButton, firstBButton, firstCButton;
        private PlayButton secondAButton, secondBButton, secondCButton;
        private PlayButton capitoButton;
        private string testoRisposta = null;
        private bool correctAnswer;

        // Posizioni delle Texture
        private Vector2 backPos;
        private Vector2 promptPos;
        private Vector2 butAPos;
        private Vector2 butBPos;
        private Vector2 butCPos;
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

            choiceTexture = content.Load<Texture2D>("GameState/choiceTexture");
            choiceHoverTexture = content.Load<Texture2D>("GameState/choiceHoverTexture");
            buttonTexture = content.Load<Texture2D>("GameState/buttonTexture");
            // buttonHoverTexture = content.Load<Texture2D>("buttonHoverTexture");
            textFont = content.Load<SpriteFont>("GameState/CustomFont");
            buttonFont = content.Load<SpriteFont>("GameState/buttonFont");
            prompt = content.Load<Texture2D>("GameState/prompt");
            story = content.Load<Texture2D>("GameState/story");

            this.Read(GameData.nameFile);

            // Load Texture diverse da gioco a gioco
            background = content.Load<Texture2D>(GameData.background);
            normalAvatar = content.Load<Texture2D>("GameState/Avatars/" + GameData.avatar);
            angryAvatar = content.Load<Texture2D>("GameState/Avatars/" + "Angry" + GameData.avatar);
            cryingAvatar = content.Load<Texture2D>("GameState/Avatars/" + "Crying" + GameData.avatar);
            happyAvatar = content.Load<Texture2D>("GameState/Avatars/" + "Happy" + GameData.avatar);
            illAvatar = content.Load<Texture2D>("GameState/Avatars/" + "Ill" + GameData.avatar);
            avatar = stringToAvatar(GameData.initEmotion);

            // Inizializzo i vettori di posizione delle Texture
            backPos = new Vector2(0, 0);
            promptPos = new Vector2((Const.DisplayDim.Y - prompt.Width) / 2 + story.Height + 200, 3 * Const.DisplayDim.X / 4 - prompt.Height / 2);
            storyPos = new Vector2((Const.DisplayDim.Y - story.Width) / 2 - 100, 3 * Const.DisplayDim.X / 4 - story.Height / 2);
            storyTextPos = storyPos + new Vector2(10, 70);
            questTextPos = promptPos + new Vector2(10, 10);
            titleTextPos = storyPos + new Vector2(10, 10);
            butAPos = promptPos + new Vector2(10, 70);
            butBPos = promptPos + new Vector2(10, 150);
            butCPos = promptPos + new Vector2(10, 230);
            butHoCapPos = storyPos + new Vector2(story.Width / 2 - buttonTexture.Width / 2, 280);
            avatarPos = new Vector2(Const.DisplayDim.Y/4 - avatar.Width/2 - 100, Const.DisplayDim.X - 3*avatar.Height/4);

            #region first Buttons

            firstAButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, false, true)
            {
                Position = butAPos,
                Text = GameData.afp.phrase,
            };

            firstAButton.Click += firstAButtonClick;

            firstBButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, false, true)
            {
                Position = butBPos,
                Text = GameData.bfp.phrase,
            };

            firstBButton.Click += firstBButtonClick;

            firstCButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, false, true)
            {
                Position = butCPos,
                Text = GameData.cfp.phrase,
            };

            firstCButton.Click += firstCButtonClick;

            firstButtons = new List<Component>()
                    {
                        firstAButton,
                        firstBButton,
                        firstCButton,
                     };
            #endregion

            #region second Buttons

            secondAButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, false, false)
            {
                Position = butAPos,
                Text = GameData.asp.phrase,
            };

            secondAButton.Click += secondAButtonClick;

            secondBButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, false, false)
            {
                Position = butBPos,
                Text = GameData.bsp.phrase,
            };

            secondBButton.Click += secondBButtonClick;

            secondCButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, false, false)
            {
                Position = butCPos,
                Text = GameData.csp.phrase,
            };

            secondCButton.Click += secondCButtonClick;

            secondButtons = new List<Component>()
                    {
                        secondAButton,
                        secondBButton,
                        secondCButton,
                     };

            #endregion

            #region other Buttons
            capitoButton = new PlayButton(buttonTexture, textFont, false)
            {
                Position = butHoCapPos,
                Text = "Ho capito!",
            };
            capitoButton.Click += capitoButtonClick;

            otherButtons = new List<Component>()
                    {
                        capitoButton
                     };
            #endregion
        }

        #region first Buttons Method
        private void firstAButtonClick(object sender, EventArgs e)
        {
            capitoButton.isActive = true;
            foreach (PlayButton button in firstButtons)
                button.isActive = false;
            state = PrimaRisposta;
            testoRisposta = GameData.afp.answer;
            avatar = stringToAvatar(GameData.afp.emotion);
            if (GameData.afp.isCorrect)
            {
                correctAnswer = true;
                Reward();
            }
        }

        private void firstBButtonClick(object sender, EventArgs e)
        {
            capitoButton.isActive = true;
            foreach (PlayButton button in firstButtons)
                button.isActive = false;
            state = PrimaRisposta;
            testoRisposta = GameData.bfp.answer;
            avatar = stringToAvatar(GameData.bfp.emotion);
            if (GameData.bfp.isCorrect)
            {
                Reward();
                correctAnswer = true;
            }
        }

        private void firstCButtonClick(object sender, EventArgs e)
        {
            capitoButton.isActive = true;
            foreach (PlayButton button in firstButtons)
                button.isActive = false;
            state = PrimaRisposta;
            avatar = stringToAvatar(GameData.cfp.emotion);
            testoRisposta = GameData.cfp.answer;
            if (GameData.cfp.isCorrect)
            {
                Reward();
                correctAnswer = true;
            }
        }
        #endregion

        #region second Buttons Method

        private void secondAButtonClick(object sender, EventArgs e)
        {
            capitoButton.isActive = true;
            foreach (PlayButton button in secondButtons)
                button.isActive = false;
            state = SecondaRisposta;
            avatar = stringToAvatar(GameData.asp.emotion);
            testoRisposta = GameData.asp.answer;
            if (GameData.asp.isCorrect)
            {
                Reward();
                correctAnswer = true;
            }
        }

        private void secondBButtonClick(object sender, EventArgs e)
        {
            capitoButton.isActive = true;
            foreach (PlayButton button in secondButtons)
                button.isActive = false;
            state = SecondaRisposta;
            testoRisposta = GameData.bsp.answer;
            avatar = stringToAvatar(GameData.bsp.emotion);
            if (GameData.bsp.isCorrect)
            {
                Reward();
                correctAnswer = true;
            }
        }

        private void secondCButtonClick(object sender, EventArgs e)
        {
            capitoButton.isActive = true;
            foreach (PlayButton button in secondButtons)
                button.isActive = false;
            state = SecondaRisposta;
            testoRisposta = GameData.csp.answer;
            avatar = stringToAvatar(GameData.csp.emotion);
            if (GameData.csp.isCorrect)
            {
                correctAnswer = true;
                Reward();
            }
        }

        #endregion

        #region other Buttons Methods
        private void capitoButtonClick(object sender, EventArgs e)
        {
            capitoButton.isActive = false;

            if (state == PrimaRisposta)
            {
                if (correctAnswer)
                {
                    state = SecondoPrompt;
                    foreach (PlayButton button in secondButtons)
                        button.isActive = true;
                }
                else
                {
                    state = PrimoPrompt;
                    foreach (PlayButton button in firstButtons)
                        button.isActive = true;
                }
            }
            else if (state == SecondaRisposta)
            {
                if (correctAnswer)
                    game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                else
                {
                    state = SecondoPrompt;
                    foreach (PlayButton button in secondButtons)
                        button.isActive = true;
                }
            }
            correctAnswer = false;
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
            spriteBatch.Draw(avatar, avatarPos, Color.White);
            spriteBatch.Draw(story, storyPos, Color.White);
            spriteBatch.DrawString(textFont, GameData.title, titleTextPos, Color.Black);

            switch (state)
            {
                case PrimoPrompt:
                    spriteBatch.Draw(prompt, promptPos, Color.White);
                    spriteBatch.DrawString(textFont, GameData.firstQuest, questTextPos, Color.Black);
                    spriteBatch.DrawString(textFont, GameData.firstPrompt, storyTextPos, Color.Black);
                    foreach (var component in firstButtons)
                        component.Draw(gameTime, spriteBatch);
                    break;
                case PrimaRisposta:
                    spriteBatch.DrawString(textFont, testoRisposta, storyTextPos, Color.Black);
                    capitoButton.Draw(gameTime, spriteBatch);
                    break;
                case SecondoPrompt:
                    spriteBatch.Draw(prompt, promptPos, Color.White);
                    spriteBatch.DrawString(textFont, GameData.secondQuest, questTextPos, Color.Black);
                    spriteBatch.DrawString(textFont, GameData.secondPrompt, storyTextPos, Color.Black);
                    foreach (var component in secondButtons)
                        component.Draw(gameTime, spriteBatch);
                    break;
                case SecondaRisposta:
                    spriteBatch.DrawString(textFont, testoRisposta, storyTextPos, Color.Black);
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
            foreach (PlayButton button in firstButtons)
                button.Update(gameTime);

            foreach (PlayButton button in secondButtons)
                button.Update(gameTime);

            foreach (PlayButton button in otherButtons)
                button.Update(gameTime);

            avatarPos = new Vector2(Const.DisplayDim.Y / 4 - avatar.Width / 2 - 100, Const.DisplayDim.X - 3*avatar.Height/4);
        }

        // Il metodo mi legge il file XML
        void Read(string nameOfFile)
        {
            XmlTextReader reader = new XmlTextReader("Gioco.xml");

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
                            reader.MoveToNextAttribute();
                            GameData.initEmotion = reader.Value;
                            reader.Read();
                            GameData.firstPrompt = reader.Value;
                            break;
                        case "fquest":
                            reader.Read();
                            GameData.firstQuest = reader.Value;
                            break;
                        case "afp":
                            reader.MoveToNextAttribute();
                            GameData.afp.isCorrect = Convert.ToBoolean(reader.Value);
                            reader.Read();
                            GameData.afp.phrase = reader.Value;
                            break;
                        case "bfp":
                            reader.MoveToNextAttribute();
                            GameData.bfp.isCorrect = Convert.ToBoolean(reader.Value);
                            reader.Read();
                            GameData.bfp.phrase = reader.Value;
                            break;
                        case "cfp":
                            reader.MoveToNextAttribute();
                            GameData.cfp.isCorrect = Convert.ToBoolean(reader.Value);
                            reader.Read();
                            GameData.cfp.phrase = reader.Value;
                            break;
                        case "oafp":
                            reader.MoveToNextAttribute();
                            GameData.afp.emotion = reader.Value;
                            reader.Read();
                            GameData.afp.answer = reader.Value;
                            break;
                        case "obfp":
                            reader.MoveToNextAttribute();
                            GameData.bfp.emotion = reader.Value;
                            reader.Read();
                            GameData.bfp.answer = reader.Value;
                            break;
                        case "ocfp":
                            reader.MoveToNextAttribute();
                            GameData.cfp.emotion = reader.Value;
                            reader.Read();
                            GameData.cfp.answer = reader.Value;
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
                            reader.MoveToNextAttribute();
                            GameData.asp.isCorrect = Convert.ToBoolean(reader.Value);
                            reader.Read();
                            GameData.asp.phrase = reader.Value;
                            break;
                        case "bsp":
                            reader.MoveToNextAttribute();
                            GameData.bsp.isCorrect = Convert.ToBoolean(reader.Value);
                            reader.Read();
                            GameData.bsp.phrase = reader.Value;
                            break;
                        case "csp":
                            reader.MoveToNextAttribute();
                            GameData.csp.isCorrect = Convert.ToBoolean(reader.Value);
                            reader.Read();
                            GameData.csp.phrase = reader.Value;
                            break;
                        case "oasp":
                            reader.MoveToNextAttribute();
                            GameData.asp.emotion = reader.Value;
                            reader.Read();
                            GameData.asp.answer = reader.Value;
                            break;
                        case "obsp":
                            reader.MoveToNextAttribute();
                            GameData.bsp.emotion = reader.Value;
                            reader.Read();
                            GameData.bsp.answer = reader.Value;
                            break;
                        case "ocsp":
                            reader.MoveToNextAttribute();
                            GameData.csp.emotion = reader.Value;
                            reader.Read();
                            GameData.csp.answer = reader.Value;
                            break;
                    }
                }
            }
            if (!GameData.isCapital)
            {
                GameData.firstPrompt = WrapText(textFont, GameData.firstPrompt, story.Width - 10);
                GameData.secondPrompt = WrapText(textFont, GameData.secondPrompt, story.Width - 10);
                GameData.afp.answer = WrapText(textFont, GameData.afp.answer, story.Width - 10);
                GameData.bfp.answer = WrapText(textFont, GameData.bfp.answer, story.Width - 10);
                GameData.cfp.answer = WrapText(textFont, GameData.cfp.answer, story.Width - 10);
                GameData.asp.answer = WrapText(textFont, GameData.asp.answer, story.Width - 10);
                GameData.bsp.answer = WrapText(textFont, GameData.bsp.answer, story.Width - 10);
                GameData.csp.answer = WrapText(textFont, GameData.csp.answer, story.Width - 10);
            }
            else
            {
                GameData.title = GameData.title.ToUpper();
                GameData.firstQuest = GameData.firstQuest.ToUpper();
                GameData.secondQuest = GameData.secondQuest.ToUpper();
                GameData.afp.phrase = GameData.afp.phrase.ToUpper();
                GameData.bfp.phrase = GameData.bfp.phrase.ToUpper();
                GameData.cfp.phrase = GameData.cfp.phrase.ToUpper();
                GameData.asp.phrase = GameData.asp.phrase.ToUpper();
                GameData.bsp.phrase = GameData.bsp.phrase.ToUpper();
                GameData.csp.phrase = GameData.csp.phrase.ToUpper();
                GameData.firstPrompt = WrapText(textFont, GameData.firstPrompt.ToUpper(), story.Width - 10);
                GameData.secondPrompt = WrapText(textFont, GameData.secondPrompt.ToUpper(), story.Width - 10);
                GameData.afp.answer = WrapText(textFont, GameData.afp.answer.ToUpper(), story.Width - 10);
                GameData.bfp.answer = WrapText(textFont, GameData.bfp.answer.ToUpper(), story.Width - 10);
                GameData.cfp.answer = WrapText(textFont, GameData.cfp.answer.ToUpper(), story.Width - 10);
                GameData.asp.answer = WrapText(textFont, GameData.asp.answer.ToUpper(), story.Width - 10);
                GameData.bsp.answer = WrapText(textFont, GameData.bsp.answer.ToUpper(), story.Width - 10);
                GameData.csp.answer = WrapText(textFont, GameData.csp.answer.ToUpper(), story.Width - 10);
            }
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

        private Texture2D stringToAvatar(string emotion)
        {
            switch (emotion)
            {
                case "Angry":
                    return angryAvatar;
                case "Happy":
                    return happyAvatar;
                case "Crying":
                    return cryingAvatar;
                case "Normal":
                    return normalAvatar;
                case "Ill":
                    return illAvatar;
                default:
                    return normalAvatar;
            }
            return null;
        }
    }
}