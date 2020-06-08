﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SocialGames
{
    public class SelStoryButton : Component
    {
        #region Fields
        private Game1 game;
        private GraphicsDevice graphicsDevice;
        private ContentManager contentManager;
        private string name;
        private Texture2D texture;
        private MouseState currentMouseInput, previousMouseInput;
        private Vector2 position;
        #endregion

        public SelStoryButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager, string name, Texture2D texture, int positionX, int positionY)
        {
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            this.contentManager = contentManager;
            this.name = name;
            this.texture = texture;
            position.X = positionX;
            position.Y = positionY;
        }

        private bool IsHovering()
        {
            if (currentMouseInput.Position.X < position.X + texture.Width &&
                currentMouseInput.Position.X > position.X &&
                currentMouseInput.Position.Y < position.Y + texture.Height &&
                currentMouseInput.Position.Y > position.Y)
            {
                return true;
            }
            return false;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Color colour = Color.White;

            if (IsHovering())
            {
                colour = Color.Gray;
            }

            spriteBatch.Draw(texture, position, colour);
        }

        public override void Update(GameTime gameTime)
        {
            previousMouseInput = currentMouseInput;
            currentMouseInput = Mouse.GetState();

            if (IsHovering() && previousMouseInput.LeftButton == ButtonState.Released && currentMouseInput.LeftButton == ButtonState.Pressed)
            {
                if (GameData.timeSpan < TimeSpan.Zero)
                {
                    switch (name)
                    {
                        case "agito":
                            GameData.isFidanz = false;
                            GameData.background = "Agito";
                            GameData.nameFile = "Agito.xml";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "bagno":
                            GameData.isFidanz = false;
                            GameData.background = "Bagno";
                            GameData.nameFile = "Usare il bagno.xml";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "camera":
                            GameData.isFidanz = false;
                            GameData.background = "Camera";
                            GameData.nameFile = "Coprirsi la bocca.xml";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "rispSbagliato":
                            GameData.isFidanz = false;
                            GameData.background = "Classe";
                            GameData.nameFile = "Risposta Sbagliata.xml";
                            if (GameData.isAlzare)
                            {
                                GameData.isAlzare = false;
                            }
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "conversazione":
                            GameData.isFidanz = false;
                            GameData.background = "Conversazione";
                            GameData.nameFile = "Conversazione.xml";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "fidanzamento":
                            GameData.isFidanz = true;
                            GameData.background = "Fidanzamento";
                            GameData.nameFile = "Fidanzamento.xml";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "parco":
                            GameData.isFidanz = false;
                            GameData.background = "Park";
                            GameData.nameFile = "Gioco.xml";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "alzareMano":
                            GameData.isFidanz = false;
                            GameData.background = "Classe";
                            GameData.nameFile = "Alzare la mano.xml";
                            GameData.isAlzare = true;
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "fila":
                            GameData.isFidanz = false;
                            GameData.background = "Fila";
                            GameData.nameFile = "La fila.xml";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "rumori":
                            GameData.isFidanz = false;
                            GameData.background = "Rumori";
                            GameData.nameFile = "Rumori forti.xml";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "spazio":
                            GameData.isFidanz = false;
                            GameData.background = "Spazio";
                            GameData.nameFile = "Spazio personale.xml";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "indipendenza":
                            GameData.isFidanz = false;
                            GameData.background = "Indipendenza";
                            GameData.nameFile = "Indipendenza.xml";
                            GameData.timeSpan = Const.TIMER;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            break;
                        case "leftArrow":
                            if (GameData.page > 1)
                                GameData.page -= 1;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            GameData.timeSpan = Const.TIMER;
                            break;
                        case "rightArrow":
                            if (GameData.page < Const.TOTALPAGES)
                                GameData.page += 1;
                            game.ChangeState(new SelStoryState(game, graphicsDevice, contentManager));
                            GameData.timeSpan = Const.TIMER;
                            break;
                        case "home":
                            game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
                            GameData.timeSpan = Const.TIMER;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
