using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SocialGames_Android
{
    public class SelStoryState : State
    {
        #region Fields
        //private Texture2D background;
        private Texture2D agito, bagno, camera, classe, conversazione, fidanzamento;
        private Texture2D parco, fidanzata, fidanzato, fila, indipendenza, rumori, spazio;
        private Texture2D agitoSel, bagnoSel, cameraSel, classeSel, conversazioneSel, fidanzamentoSel;
        private Texture2D parcoSel, fidanzataSel, fidanzatoSel, filaSel, indipendenzaSel, rumoriSel, spazioSel;
        private Texture2D leftArrow, rightArrow;
        private Texture2D gioca, gioca_hover;
        private Texture2D home;
        private Texture2D background;
        private Texture2D camera_cartello, agito_cartello, fila_cartello, bagno_cartello, parco_cartello, fidanzamento_cartello;
        private Texture2D classe_cartello, rumori_cartello, indipendenza_cartello, spazio_cartello, alzareMano_cartello, conversazione_cartello;
        private SelStoryButton agitoBtn, bagnoBtn, cameraBtn;
        private SelStoryButton rispSbagliato, conversazioneBtn, fidanzamentoBtn;
        private SelStoryButton parcoBtn, alzareManoBtn, filaBtn;
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
            agito = content.Load<Texture2D>("SelStoryState/Agito");
            bagno = content.Load<Texture2D>("SelStoryState/Bagno");
            camera = content.Load<Texture2D>("SelStoryState/Camera");
            classe = content.Load<Texture2D>("SelStoryState/Classe");
            conversazione = content.Load<Texture2D>("SelStoryState/Conversazione");
            fidanzamento = content.Load<Texture2D>("SelStoryState/Fidanzamento");
            fidanzato = content.Load<Texture2D>("SelStoryState/Fidanzato");
            fila = content.Load<Texture2D>("SelStoryState/Fila");
            rumori = content.Load<Texture2D>("SelStoryState/Rumori");
            spazio = content.Load<Texture2D>("SelStoryState/Spazio");
            indipendenza = content.Load<Texture2D>("SelStoryState/Indipendenza");
            parco = content.Load<Texture2D>("SelStoryState/Park");
            agitoSel = content.Load<Texture2D>("SelStoryState/AgitoSel");
            bagnoSel = content.Load<Texture2D>("SelStoryState/BagnoSel");
            cameraSel = content.Load<Texture2D>("SelStoryState/CameraSel");
            classeSel = content.Load<Texture2D>("SelStoryState/ClasseSel");
            conversazioneSel = content.Load<Texture2D>("SelStoryState/ConversazioneSel");
            fidanzamentoSel = content.Load<Texture2D>("SelStoryState/FidanzamentoSel");
            fidanzatoSel = content.Load<Texture2D>("SelStoryState/FidanzatoSel");
            filaSel = content.Load<Texture2D>("SelStoryState/FilaSel");
            rumoriSel = content.Load<Texture2D>("SelStoryState/RumoriSel");
            spazioSel = content.Load<Texture2D>("SelStoryState/SpazioSel");
            indipendenzaSel = content.Load<Texture2D>("SelStoryState/IndipendenzaSel");
            parcoSel = content.Load<Texture2D>("SelStoryState/ParkSel");
            leftArrow = content.Load<Texture2D>("LeftArrow");
            rightArrow = content.Load<Texture2D>("RightArrow");
            home = content.Load<Texture2D>("home");
            background = content.Load<Texture2D>("SelBackground");
            // Tasto gioca per iniziare la storia
            gioca = content.Load<Texture2D>("gioca");
            gioca_hover = content.Load<Texture2D>("gioca_hover");

            #region Cartels
            camera_cartello = content.Load<Texture2D>("SelStoryState/camera_cartello");
            agito_cartello = content.Load<Texture2D>("SelStoryState/agito_cartello");
            fila_cartello = content.Load<Texture2D>("SelStoryState/fila_cartello");
            bagno_cartello = content.Load<Texture2D>("SelStoryState/bagno_cartello");
            classe_cartello = content.Load<Texture2D>("SelStoryState/classe_cartello");
            rumori_cartello = content.Load<Texture2D>("SelStoryState/rumori_cartello");
            indipendenza_cartello = content.Load<Texture2D>("SelStoryState/indipendenza_cartello");
            spazio_cartello = content.Load<Texture2D>("SelStoryState/spazio_cartello");
            parco_cartello = content.Load<Texture2D>("SelStoryState/park_cartello");
            alzareMano_cartello = content.Load<Texture2D>("SelStoryState/alzareMano_cartello");
            fidanzamento_cartello = content.Load<Texture2D>("SelStoryState/fidanzamento_cartello");
            conversazione_cartello = content.Load<Texture2D>("SelStoryState/conversazione_cartello");
            #endregion

            #region Buttons
            // Arrow Buttons
            leftArrowBtn = new SelStoryButton(game, graphicsDevice, contentManager, "leftArrow", leftArrow, 10, 516);
            rightArrowBtn = new SelStoryButton(game, graphicsDevice, contentManager, "rightArrow", rightArrow, 1840, 516);
            // Home Button
            homeButton = new SelStoryButton(game, graphicsDevice, contentManager, "home", home, Const.MARGINHOMEBTN, Const.MARGINHOMEBTN);
            // Play Button 
            giocaButton = new MenuButton(game, graphicsDevice, contentManager, "start", gioca, gioca_hover, 1670, 1000);

            if (GameData.page == 1)
            {
                // First line first page
                agitoBtn = new SelStoryButton(game, graphicsDevice, contentManager, "agito", agito, 95, 111);
                bagnoBtn = new SelStoryButton(game, graphicsDevice, contentManager, "bagno", bagno, 190 + agito.Width, 111);
                cameraBtn = new SelStoryButton(game, graphicsDevice, contentManager, "camera", camera, 285 + 2 * (agito.Width), 111);
                // Second Line first page
                rispSbagliato = new SelStoryButton(game, graphicsDevice, contentManager, "rispSbagliato", classe, 95, 301 + agito.Height);
                conversazioneBtn = new SelStoryButton(game, graphicsDevice, contentManager, "conversazione", conversazione, 190 + agito.Width, 301 + agito.Height);
                fidanzamentoBtn = new SelStoryButton(game, graphicsDevice, contentManager, "fidanzamento", fidanzamento, 285 + 2 * (agito.Width), 301 + agito.Height);
                // List of all story buttons
                buttons = new List<SelStoryButton>
            {
                agitoBtn,
                bagnoBtn,
                cameraBtn,
                rispSbagliato,
                conversazioneBtn,
                fidanzamentoBtn,
                homeButton
            };
            }
            else if (GameData.page == 2)
            {
                // First line second page
                parcoBtn = new SelStoryButton(game, graphicsDevice, contentManager, "parco", parco, 95, 111);
                alzareManoBtn = new SelStoryButton(game, graphicsDevice, contentManager, "alzareMano", classe, 190 + agito.Width, 111);
                filaBtn = new SelStoryButton(game, graphicsDevice, contentManager, "fila", fila, 285 + 2 * (agito.Width), 111);
                // Second Line second page
                indipendenzaBtn = new SelStoryButton(game, graphicsDevice, contentManager, "indipendenza", indipendenza, 95, 301 + agito.Height);
                rumoriBtn = new SelStoryButton(game, graphicsDevice, contentManager, "rumori", rumori, 190 + agito.Width, 301 + agito.Height);
                spazioBtn = new SelStoryButton(game, graphicsDevice, contentManager, "spazio", spazio, 285 + 2 * (agito.Width), 301 + agito.Height);
                // List of all story buttons
                buttons = new List<SelStoryButton>
            {
                parcoBtn,
                alzareManoBtn,
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
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            if (GameData.page == 1)
            {
                spriteBatch.Draw(camera_cartello, new Vector2(392 + 2 * (agito.Width), 120 + camera.Height), Color.White);
                spriteBatch.Draw(agito_cartello, new Vector2(202, 120 + agito.Height), Color.White);
                spriteBatch.Draw(bagno_cartello, new Vector2(297 + agito.Width, 120 + agito.Height), Color.White);
                spriteBatch.Draw(classe_cartello, new Vector2(202, 311 + (2 * agito.Height)), Color.White);
                spriteBatch.Draw(fidanzamento_cartello, new Vector2(392 + 2 * (agito.Width), 311 + (2 * agito.Height)), Color.White);
                spriteBatch.Draw(conversazione_cartello, new Vector2(297 + agito.Width, 311 + (2 * agito.Height)), Color.White);
            }
            else
            {
                spriteBatch.Draw(fila_cartello, new Vector2(392 + 2 * (agito.Width), 120 + fila.Height), Color.White);
                spriteBatch.Draw(rumori_cartello, new Vector2(297 + agito.Width, 311 + (2 * agito.Height)), Color.White);
                spriteBatch.Draw(indipendenza_cartello, new Vector2(202, 311 + (2 * agito.Height)), Color.White);
                spriteBatch.Draw(spazio_cartello, new Vector2(392 + 2 * (agito.Width), 311 + (2 * agito.Height)), Color.White);
                spriteBatch.Draw(parco_cartello, new Vector2(202, 120 + fila.Height), Color.White);
                spriteBatch.Draw(alzareMano_cartello, new Vector2(297 + agito.Width, 120 + fila.Height), Color.White);
            }

            switch (GameData.background)
            {
                case "Agito":
                    if (GameData.page == 1)
                    {
                        buttons.Remove(agitoBtn);
                        position.X = 95;
                        position.Y = 111;
                        spriteBatch.Draw(agitoSel, position, Color.White);
                    }
                    break;
                case "Bagno":
                    if (GameData.page == 1)
                    {
                        buttons.Remove(bagnoBtn);
                        position.X = 190 + agito.Width;
                        position.Y = 111;
                        spriteBatch.Draw(bagnoSel, position, Color.White);
                    }
                    break;
                case "Camera":
                    if (GameData.page == 1)
                    {
                        buttons.Remove(cameraBtn);
                        position.X = 285 + 2 * (agito.Width);
                        position.Y = 111;
                        spriteBatch.Draw(cameraSel, position, Color.White);
                    }
                    break;
                case "Classe":
                    if (GameData.isAlzare && GameData.page == 2)
                    {
                        buttons.Remove(alzareManoBtn);
                        position.X = 190 + agito.Width;
                        position.Y = 111;
                        spriteBatch.Draw(classeSel, position, Color.White);
                    }
                    else if (!GameData.isAlzare && GameData.page == 1)
                    {
                        buttons.Remove(rispSbagliato);
                        position.X = 95;
                        position.Y = 301 + agito.Height;
                        spriteBatch.Draw(classeSel, position, Color.White);
                    }
                    break;
                case "Conversazione":
                    if (GameData.page == 1)
                    {
                        buttons.Remove(conversazioneBtn);
                        position.X = 190 + agito.Width;
                        position.Y = 301 + agito.Height;
                        spriteBatch.Draw(conversazioneSel, position, Color.White);
                    }
                    break;
                case "Fidanzamento":
                case "Fidanzato":
                case "Fidanzata":
                    if (GameData.page == 1)
                    {
                        buttons.Remove(fidanzamentoBtn);
                        position.X = 285 + 2 * (agito.Width);
                        position.Y = 301 + agito.Height;
                        spriteBatch.Draw(fidanzamentoSel, position, Color.White);
                    }
                    break;
                case "Park":
                    if (GameData.page == 2)
                    {
                        buttons.Remove(parcoBtn);
                        position.X = 95;
                        position.Y = 111;
                        spriteBatch.Draw(parcoSel, position, Color.White);
                    }
                    break;
                case "Fila":
                    if (GameData.page == 2)
                    {
                        buttons.Remove(filaBtn);
                        position.X = 285 + 2 * (agito.Width);
                        position.Y = 111;
                        spriteBatch.Draw(filaSel, position, Color.White);
                    }
                    break;
                case "Rumori":
                    if (GameData.page == 2)
                    {
                        buttons.Remove(rumoriBtn);
                        position.X = 190 + agito.Width;
                        position.Y = 301 + agito.Height;
                        spriteBatch.Draw(rumoriSel, position, Color.White);
                    }
                    break;
                case "Spazio":
                    if (GameData.page == 2)
                    {
                        buttons.Remove(spazioBtn);
                        position.X = 285 + 2 * (agito.Width);
                        position.Y = 301 + agito.Height;
                        spriteBatch.Draw(spazioSel, position, Color.White);
                    }
                    break;
                case "Indipendenza":
                    if (GameData.page == 2)
                    {
                        buttons.Remove(indipendenzaBtn);
                        position.X = 95;
                        position.Y = 301 + agito.Height;
                        spriteBatch.Draw(indipendenzaSel, position, Color.White);
                    }
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
