using System;

namespace SocialGames
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static Game1 Game;

        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
            {
                Game = game;
                Game.Run();
            }
        }
    }
#endif
}
