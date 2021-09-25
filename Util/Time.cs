using Microsoft.Xna.Framework;

namespace Namespace.Util
{
    /// <summary>
    /// Time class providing static info on passed time.
    /// </summary>
    public static class Time
    {
        public static double Delta;
        public static float DeltaF => (float)Delta;
        public static double Total = 0;
        public static float TotalF => (float)Total;

        public static void Update(GameTime gameTime)
        {
            Delta = gameTime.ElapsedGameTime.TotalSeconds;
            Total += gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
