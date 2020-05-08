using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SocialGames
{
    public class Const : Game1
    {
        public static Vector2 DisplayDim = new Vector2(
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height, 
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width);
        public static Vector2 CenterScreen
            => new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2f, 
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2f);
        public const int TOPMARGINBTN = 200;
        public const int LEFTMARGINBTN = 850;
        public const int TOTALPAGES = 2;
        public const int LEFTMARGINSELAVATAR = 380;
        public const int TOPMARGINSELAVATAR = 240;
        public const int MARGINHOMEBTN = 50;
        public static TimeSpan TIMER = TimeSpan.FromMilliseconds(200);
    }
}
