#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace LogicBall
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        private static LogicBall gameInstance;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            gameInstance = new LogicBall();
            gameInstance.Run();
        }

        public static LogicBall Game { get { return gameInstance; } }
    }
#endif
}
