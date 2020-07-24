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
using System.Drawing;

namespace SocialGames_Android
{
    public class GameState : State
    {
        #region Costanti
        private const int PrimoPrompt = 1;
        private const int SecondoPrompt = 3;
        private const int PrimaRisposta = 2;
        private const int SecondaRisposta = 4;
        private const int Fine = 5;
        private const int Home = 0;
        private const bool Boy = true;
        private const bool Girl = false;
        #endregion

        #region Fields

        private Texture2D initBackground, endBackground, background;
        private SpriteFont textFont, titleFont;
        private SpriteFont buttonFont;
        private Texture2D prompt;
        private Texture2D story;
        private Texture2D choiceTexture;
        private Texture2D choiceHoverTexture;
        private Texture2D buttonTexture;
        private Texture2D homeButText;
        private List<Component> firstButtons, secondButtons, otherButtons, buttons;
        private Texture2D buttonHoverTexture;
        private Texture2D avatar;
        private Texture2D angryAvatar, illAvatar, cryingAvatar, happyAvatar, normalAvatar;
        private bool sex;
        private int state;

        private PlayButton firstAButton, firstBButton, firstCButton;
        private PlayButton secondAButton, secondBButton, secondCButton;
        private PlayButton capitoButton;
        private PlayButton homeButton;
        private string testoRisposta = null;
        private string promptString, questString;
        private bool correctAnswer, isPromptActive;
        private Reward reward;

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
        private Vector2 homeButPos;

        #endregion

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            this.game = game;
            state = PrimoPrompt;
            sex = GameData.avatar.Contains("Boy");

            #region Texture Grafica

            choiceTexture = content.Load<Texture2D>("GameState/choiceTexture");
            choiceHoverTexture = content.Load<Texture2D>("GameState/choiceHoverTexture");
            buttonTexture = content.Load<Texture2D>("GameState/buttonTexture");
            buttonHoverTexture = content.Load<Texture2D>("GameState/buttonHoverTexture");
            homeButText = content.Load<Texture2D>("home");
            textFont = content.Load<SpriteFont>("GameState/CustomFont");
            buttonFont = content.Load<SpriteFont>("GameState/ButtonFont");
            titleFont = content.Load<SpriteFont>("GameState/TitleFont");
            prompt = content.Load<Texture2D>("GameState/prompt");
            story = content.Load<Texture2D>("GameState/story");
            #endregion

            this.Read(GameData.nameFile);

            #region Texture Storia
            // Load Texture diverse da gioco a gioco
            if (GameData.nameFile == "Fidanzamento.xml")
            {
                if (sex == Boy)
                    GameData.background = "Fidanzata";
                else
                    GameData.background = "Fidanzato";
            }
            initBackground = content.Load<Texture2D>("StoriesBackground/" + GameData.background);
            endBackground = content.Load<Texture2D>("StoriesBackground/end" + GameData.background);

            normalAvatar = content.Load<Texture2D>("GameState/Avatars/" + GameData.avatar);
            angryAvatar = content.Load<Texture2D>("GameState/Avatars/" + "Angry" + GameData.avatar);
            cryingAvatar = content.Load<Texture2D>("GameState/Avatars/" + "Crying" + GameData.avatar);
            happyAvatar = content.Load<Texture2D>("GameState/Avatars/" + "Happy" + GameData.avatar);
            illAvatar = content.Load<Texture2D>("GameState/Avatars/" + "Ill" + GameData.avatar);
            avatar = stringToAvatar(GameData.initEmotion);
            #endregion

            #region Vettori Posizione Elementi
            // Inizializzo i vettori di posizione delle Texture
            backPos = new Vector2(0, 0);
            storyPos = new Vector2(Const.DisplayDim.Y / 5 - story.Width / 2, 3 * Const.DisplayDim.X / 4 - story.Height / 2);
            promptPos = storyPos + new Vector2(story.Width + 10, 0);
            storyTextPos = storyPos + new Vector2(10, 70);
            questTextPos = promptPos + new Vector2(10, 10);
            titleTextPos = storyPos + new Vector2(10, 10);
            butAPos = promptPos + new Vector2(10, 70);
            butBPos = promptPos + new Vector2(10, 150);
            butCPos = promptPos + new Vector2(10, 230);
            butHoCapPos = storyPos + new Vector2(story.Width / 2 - buttonTexture.Width / 2, 280);
            homeButPos = new Vector2(Const.MARGINHOMEBTN, Const.MARGINHOMEBTN);
            avatarPos = new Vector2(0, 0); // Viene gestita la sua posizione nel metodo Update()
            #endregion

            #region first Buttons

            firstAButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, content, false, true)
            {
                Position = butAPos,
                Text = GameData.afp.phrase,
            };

            firstAButton.Click += firstAButtonClick;

            firstBButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, content, false, true)
            {
                Position = butBPos,
                Text = GameData.bfp.phrase,
            };

            firstBButton.Click += firstBButtonClick;

            firstCButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, content, false, true)
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

            secondAButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, content, false, false)
            {
                Position = butAPos,
                Text = GameData.asp.phrase,
            };

            secondAButton.Click += secondAButtonClick;

            secondBButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, content, false, false)
            {
                Position = butBPos,
                Text = GameData.bsp.phrase,
            };

            secondBButton.Click += secondBButtonClick;

            secondCButton = new PlayButton(choiceTexture, choiceHoverTexture, buttonFont, content, false, false)
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
            capitoButton = new PlayButton(buttonTexture, buttonHoverTexture, true, false)
            {
                Position = butHoCapPos,
            };
            capitoButton.Click += capitoButtonClick;

            homeButton = new PlayButton(homeButText, null, false, true)
            {
                Position = homeButPos
            };
            homeButton.Click += homeButtonClick;

            otherButtons = new List<Component>()
                    {
                        capitoButton,
                        homeButton
                     };
            #endregion

            #region Inizializzazione altri elementi

            reward = new Reward(content);
            reward.UpdateReward(0);
            isPromptActive = true;

            foreach (PlayButton button in secondButtons)
                button.isActive = false;

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
                reward.UpdateReward();
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
                reward.UpdateReward();
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
                reward.UpdateReward();
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
                reward.UpdateReward();
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
                reward.UpdateReward();
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
                reward.UpdateReward();
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
                    foreach (PlayButton button in secondButtons)
                        button.isActive = false;
                }
            }
            else if (state == SecondaRisposta)
            {
                if (correctAnswer)
                    game.ChangeState(new EndGameState(game, graphicsDevice, contentManager));
                else
                {
                    state = SecondoPrompt;
                    foreach (PlayButton button in secondButtons)
                        button.isActive = true;
                    foreach (PlayButton button in firstButtons)
                        button.isActive = false;
                }
            }
            correctAnswer = false;
        }

        private void homeButtonClick(object sender, EventArgs e)
        {
            game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
        }

        #endregion

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, backPos, Microsoft.Xna.Framework.Color.White);
            spriteBatch.Draw(avatar, avatarPos, Microsoft.Xna.Framework.Color.White);
            spriteBatch.Draw(story, storyPos, Microsoft.Xna.Framework.Color.White);
            
            if (isPromptActive)
            {
                spriteBatch.Draw(prompt, promptPos, Microsoft.Xna.Framework.Color.White);
                foreach (var component in buttons)
                    component.Draw(gameTime, spriteBatch);
            }
            else
                capitoButton.Draw(gameTime, spriteBatch);

            reward.Draw(spriteBatch);
            homeButton.Draw(gameTime, spriteBatch);

            spriteBatch.End();
            spriteBatch.Begin(transformMatrix: Const.scaleMatrix);

            spriteBatch.DrawString(textFont, GameData.title, titleTextPos, Microsoft.Xna.Framework.Color.Black);
            spriteBatch.DrawString(textFont, promptString, storyTextPos, Microsoft.Xna.Framework.Color.Black,
                            0.0f, new Vector2(0, 0), AdaptiveText(textFont, promptString, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100)), new SpriteEffects(), 0.0f);
            if (isPromptActive)
                spriteBatch.DrawString(textFont, questString, questTextPos, Microsoft.Xna.Framework.Color.Black);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (PlayButton button in firstButtons)
                button.Update(gameTime);

            foreach (PlayButton button in secondButtons)
                button.Update(gameTime);

            foreach (PlayButton button in otherButtons)
                button.Update(gameTime);

            avatarPos = new Vector2(Const.DisplayDim.Y / 5 - avatar.Width / 2, Const.DisplayDim.X/12);

            switch (state)
            {
                case PrimoPrompt:
                    background = initBackground;
                    questString = GameData.firstQuest;
                    promptString = GameData.firstPrompt;
                    isPromptActive = true;
                    buttons = firstButtons;
                    break;
                case PrimaRisposta:
                    background = initBackground;
                    questString = GameData.firstQuest;
                    promptString = testoRisposta;
                    isPromptActive = false;
                    break;
                case SecondoPrompt:
                    background = endBackground;
                    questString = GameData.secondQuest;
                    promptString = GameData.secondPrompt;
                    isPromptActive = true;
                    buttons = secondButtons;
                    break;
                case SecondaRisposta:
                    background = endBackground;
                    questString = GameData.secondQuest;
                    promptString = testoRisposta;
                    isPromptActive = false;
                    break;
            }
        }

        // Il metodo mi legge il file XML
        void Read(string nameOfFile)
        {
            //XmlTextReader reader = new XmlTextReader("Gioco.xml");
            XmlTextReader reader = new XmlTextReader(TitleContainer.OpenStream(@"Content/Data/"+nameOfFile));

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
                GameData.firstPrompt = WrapText(textFont, GameData.firstPrompt, (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.firstPrompt, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.secondPrompt = WrapText(textFont, GameData.secondPrompt, (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.secondPrompt, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.afp.answer = WrapText(textFont, GameData.afp.answer, (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.afp.answer, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.bfp.answer = WrapText(textFont, GameData.bfp.answer, (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.bfp.answer, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.cfp.answer = WrapText(textFont, GameData.cfp.answer, (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.cfp.answer, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.asp.answer = WrapText(textFont, GameData.asp.answer, (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.asp.answer, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.bsp.answer = WrapText(textFont, GameData.bsp.answer, (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.bsp.answer, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.csp.answer = WrapText(textFont, GameData.csp.answer, (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.csp.answer, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
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
                GameData.firstPrompt = WrapText(textFont, GameData.firstPrompt.ToUpper(), (story.Width - 10) * (1/AdaptiveText(textFont, GameData.firstPrompt, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.secondPrompt = WrapText(textFont, GameData.secondPrompt.ToUpper(), (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.secondPrompt, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.afp.answer = WrapText(textFont, GameData.afp.answer.ToUpper(), (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.afp.answer, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.bfp.answer = WrapText(textFont, GameData.bfp.answer.ToUpper(), (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.bfp.answer, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.cfp.answer = WrapText(textFont, GameData.cfp.answer.ToUpper(), (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.cfp.answer, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.asp.answer = WrapText(textFont, GameData.asp.answer.ToUpper(), (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.asp.answer, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.bsp.answer = WrapText(textFont, GameData.bsp.answer.ToUpper(), (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.bsp.answer, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
                GameData.csp.answer = WrapText(textFont, GameData.csp.answer.ToUpper(), (story.Width - 10) * (1 / AdaptiveText(textFont, GameData.csp.answer, new Microsoft.Xna.Framework.Rectangle(0, 0, story.Width - 10, story.Height - 100))));
            }
        }

        // La funzione mi regola la dimensione della scritta di modo che non ecceda la dimensione del rettangolo
        public float AdaptiveText(SpriteFont spriteFont, string text, Microsoft.Xna.Framework.Rectangle rectangle)
        {
            // Tengo in considerazione anche lo spazio che mi occuperanno le righe
            //float approximateNumberOfLine = spriteFont.MeasureString(text).X/(rectangle.Width);
            // Ottenuto con trial and error
            Vector2 size = spriteFont.MeasureString(text);  //new Vector2(0,approximateNumberOfLine + 2) + spriteFont.MeasureString(text);
            float area = rectangle.Width * rectangle.Height;
            float fontArea = size.X * size.Y;

            float ratio = area / fontArea;

            // Se il testo mi occupa meno spazio dell'area disponibile
            if (ratio > 1)
                return 1f;
            else
                return ratio;
        }

        public string WrapText(SpriteFont spriteFont, string text, float maxLineWidth)
        {
            float relativeLineWidth = maxLineWidth;
            string[] words = text.Split(' ');
            StringBuilder sb = new StringBuilder();
            float lineWidth = 0f;
            float spaceWidth = spriteFont.MeasureString(" ").X * AdaptiveText(spriteFont, text, new Microsoft.Xna.Framework.Rectangle(0, 0, 490, 225));

            if(AdaptiveText(spriteFont, text, new Microsoft.Xna.Framework.Rectangle(0, 0, 590, 200)) < 1)
                relativeLineWidth = maxLineWidth / AdaptiveText(spriteFont, text, new Microsoft.Xna.Framework.Rectangle(0, 0, 490, 225));

            foreach (string word in words)
            {
                Vector2 size = spriteFont.MeasureString(word);

                if (lineWidth + size.X < relativeLineWidth)
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
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
    }
}