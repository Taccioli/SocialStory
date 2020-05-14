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
        private Texture2D agito, bagno, camera, classe, conversazione, fidanzamento;
        private Texture2D fidanzata, fidanzato, fila, indipendenza, rumori, spazio;
        private Texture2D storySel1, storySel2;
        private Texture2D leftArrow, rightArrow;
        private Texture2D gioca, gioca_hover;
        private Texture2D home;
        private SelStoryButton agitoBtn, bagnoBtn, cameraBtn;
        private SelStoryButton classeBtn, conversazioneBtn, fidanzamentoBtn;
        private SelStoryButton fidanzataBtn, fidanzatoBtn, filaBtn;
        private SelStoryButton indipendenzaBtn, rumoriBtn, spazioBtn;
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
            agito = content.Load<Texture2D>("SelStoryState/Agito");
            bagno = content.Load<Texture2D>("SelStoryState/Bagno");
            camera = content.Load<Texture2D>("SelStoryState/Camera");
            classe = content.Load<Texture2D>("SelStoryState/Classe");
            conversazione = content.Load<Texture2D>("SelStoryState/Conversazione");
            fidanzamento = content.Load<Texture2D>("SelStoryState/Fidanzamento");
            fidanzata = content.Load<Texture2D>("SelStoryState/Fidanzata");
            fidanzato = content.Load<Texture2D>("SelStoryState/Fidanzato");
            fila = content.Load<Texture2D>("SelStoryState/Fila");
            rumori = content.Load<Texture2D>("SelStoryState/Rumori");
            spazio = content.Load<Texture2D>("SelStoryState/Spazio");
            indipendenza = content.Load<Texture2D>("SelStoryState/Indipendenza");
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
                agitoBtn = new SelStoryButton(game, graphicsDevice, contentManager, "agito", agito, 95, 201);
                bagnoBtn = new SelStoryButton(game, graphicsDevice, contentManager, "bagno", bagno, 190 + agito.Width, 201);
                cameraBtn = new SelStoryButton(game, graphicsDevice, contentManager, "camera", camera, 285 + 2 * (agito.Width), 201);
                // Second Line first page
                classeBtn = new SelStoryButton(game, graphicsDevice, contentManager, "classe", classe, 95, 301 + agito.Height);
                conversazioneBtn = new SelStoryButton(game, graphicsDevice, contentManager, "conversazione", conversazione, 190 + agito.Width, 301 + agito.Height);
                fidanzamentoBtn = new SelStoryButton(game, graphicsDevice, contentManager, "fidanzamento", fidanzamento, 285 + 2 * (agito.Width), 301 + agito.Height);
                // List of all story buttons
                buttons = new List<SelStoryButton>
            {
                agitoBtn,
                bagnoBtn,
                cameraBtn,
                classeBtn,
                conversazioneBtn,
                fidanzamentoBtn,
                homeButton
            };
            }
            else if (GameData.page == 2)
            {
                // First line second page
                fidanzataBtn = new SelStoryButton(game, graphicsDevice, contentManager, "fidanzata", fidanzata, 105, 201);
                fidanzatoBtn = new SelStoryButton(game, graphicsDevice, contentManager, "fidanzato", fidanzato, 210 + agito.Width, 201);
                filaBtn = new SelStoryButton(game, graphicsDevice, contentManager, "fila", fila, 315 + 2 * (agito.Width), 201);
                // Second Line second page
                indipendenzaBtn = new SelStoryButton(game, graphicsDevice, contentManager, "indipendenza", indipendenza, 105, 301 + agito.Height);
                rumoriBtn = new SelStoryButton(game, graphicsDevice, contentManager, "rumori", rumori, 210 + agito.Width, 301 + agito.Height);
                spazioBtn = new SelStoryButton(game, graphicsDevice, contentManager, "spazio", spazio, 315 + 2 * (agito.Width), 301 + agito.Height);
                // List of all story buttons
                buttons = new List<SelStoryButton>
            {
                fidanzataBtn,
                fidanzatoBtn,
                filaBtn,
                indipendenzaBtn,
                indipendenzaBtn,
                rumoriBtn,
                spazioBtn,
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

            switch (GameData.story)
            {
                case "agito":
                    buttons.Remove(agitoBtn);
                    position.X = 120;
                    position.Y = 259;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "bagno":
                    buttons.Remove(bagnoBtn);
                    position.X = 140 + agito.Width;
                    position.Y = 259;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "camera":
                    buttons.Remove(cameraBtn);
                    position.X = 160 + 2 * (agito.Width);
                    position.Y = 259;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "classe":
                    buttons.Remove(classeBtn);
                    position.X = 180 + 3 * (agito.Width);
                    position.Y = 259;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "conversazione":
                    buttons.Remove(conversazioneBtn);
                    position.X = 120;
                    position.Y = 359 + agito.Height;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "fidanzamento":
                    buttons.Remove(fidanzamentoBtn);
                    position.X = 140 + agito.Width;
                    position.Y = 359 + agito.Height;
                    spriteBatch.Draw(storySel1, position, Color.White);
                    break;
                case "fidanzata":
                    buttons.Remove(fidanzataBtn);
                    position.X = 120;
                    position.Y = 259;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                case "fidanzato":
                    buttons.Remove(fidanzatoBtn);
                    position.X = 140 + agito.Width;
                    position.Y = 259;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                case "fila":
                    buttons.Remove(filaBtn);
                    position.X = 160 + 2 * (agito.Width);
                    position.Y = 259;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                case "rumori":
                    buttons.Remove(rumoriBtn);
                    position.X = 180 + 3 * (agito.Width);
                    position.Y = 259;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                case "spazio":
                    buttons.Remove(spazioBtn);
                    position.X = 120;
                    position.Y = 359 + agito.Height;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                case "indipendenza":
                    buttons.Remove(indipendenzaBtn);
                    position.X = 140 + agito.Width;
                    position.Y = 359 + agito.Height;
                    spriteBatch.Draw(storySel2, position, Color.White);
                    break;
                default:
                    break;
            }

            foreach (SelStoryButton button in buttons)
                button.Draw(gameTime, spriteBatch);

            if (GameData.isStart)
                giocaButton.Draw(gameTime, spriteBatch);
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
