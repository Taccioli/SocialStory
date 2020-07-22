using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SocialGames_Android
{
    public class Const : Game1
    {
        public static Vector2 DisplayDim = new Vector2(
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height,
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width);
        public static Vector2 CenterScreen
            => new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2f,
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2f);
        public const int TOPMARGINBTN = 100;
        public const int LEFTMARGINBTN = 850;
        public const int TOTALPAGES = 2;
        public const int LEFTMARGINSELAVATAR = 380;
        public const int TOPMARGINSELAVATAR = 240;
        public const int MARGINHOMEBTN = 20;
        public static TimeSpan TIMER = TimeSpan.FromMilliseconds(200);
    }
}
