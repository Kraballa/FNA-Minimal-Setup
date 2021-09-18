using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Namespace.Util
{
    /// <summary>
    /// Time class providing static info on passed time.
    /// </summary>
    public static class Time
    {
        public static double Delta;
        public static double DeltaF => (float)Delta;
        public static double Total = 0;
        public static double TotalF => (float)Total;

        public static void Update(GameTime gameTime)
        {
            Delta = gameTime.ElapsedGameTime.TotalSeconds;
            Total += gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
