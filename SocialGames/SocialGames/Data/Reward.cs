using System;
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
    class Reward
    {
        private Texture2D shortText, longText, rewardText; //reward0, reward1, reward2, reward3, 
                            //reward4, reward5, reward6, reward7, reward8, reward9, rewardMAX, actualReward;
        private SpriteFont font;
        private Vector2 rewardPos, textPos;
        private string reward;

        public Reward(ContentManager content)
        {
            shortText = content.Load<Texture2D>("GameState/Rewards/ShortReward");
            longText = content.Load<Texture2D>("GameState/Rewards/LongReward");
            font = content.Load<SpriteFont>("GameState/Rewards/Font");
            //reward0 = content.Load<Texture2D>("GameState/Rewards/0");
            //reward1 = content.Load<Texture2D>("GameState/Rewards/1");
            //reward2 = content.Load<Texture2D>("GameState/Rewards/2");
            //reward3 = content.Load<Texture2D>("GameState/Rewards/3");
            //reward4 = content.Load<Texture2D>("GameState/Rewards/4");
            //reward5 = content.Load<Texture2D>("GameState/Rewards/5");
            //reward6 = content.Load<Texture2D>("GameState/Rewards/6");
            //reward7 = content.Load<Texture2D>("GameState/Rewards/7");
            //reward8 = content.Load<Texture2D>("GameState/Rewards/8");
            //reward9 = content.Load<Texture2D>("GameState/Rewards/9");
            //rewardMAX = content.Load<Texture2D>("GameState/Rewards/MAX");
            rewardPos = new Vector2(3 * Const.DisplayDim.Y / 4, Const.MARGINHOMEBTN);
            textPos = rewardPos + new Vector2(208, 20);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(rewardText, rewardPos, Color.White);
            spriteBatch.DrawString(font, reward, textPos, Color.DarkGray);
        }

        public void UpdateReward(int amount=1)
        {
            GameData.rewardAmount += amount;
            if (GameData.rewardAmount < 10)
            {
                textPos = rewardPos + new Vector2(188, 20);
                reward = GameData.rewardAmount.ToString();
                rewardText = shortText;
            }
            else
            {
                reward = "MAX";
                textPos = rewardPos + new Vector2(178, 20);
                rewardText = longText;
            }
            //switch (GameData.rewardAmount)
            //{
            //    case 0:
            //        actualReward = reward0;
            //        break;
            //    case 1:
            //        actualReward = reward1;
            //        break;
            //    case 2:
            //        actualReward = reward2;
            //        break;
            //    case 3:
            //        actualReward = reward3;
            //        break;
            //    case 4:
            //        actualReward = reward4;
            //        break;
            //    case 5:
            //        actualReward = reward5;
            //        break;
            //    case 6:
            //        actualReward = reward6;
            //        break;
            //    case 7:
            //        actualReward = reward7;
            //        break;
            //    case 8:
            //        actualReward = reward8;
            //        break;
            //    case 9:
            //        actualReward = reward9;
            //        break;
            //    default:
            //        actualReward = rewardMAX;
            //        break;
            //}
        }
    }
}
