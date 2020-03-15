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
    public class Const
    {
        public static Vector2 DisplayDim = new Vector2(
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height, 
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width);
        public static Vector2 CenterScreen
            => new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2f, 
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2f);
    }
}
