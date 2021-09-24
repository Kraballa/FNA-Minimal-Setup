using Microsoft.Xna.Framework;
using Namespace.Util;
using System;

namespace Namespace.Collision
{
    public class Hitbox : Collider
    {
        public RectangleF Rect;

        public Hitbox(RectangleF bounds)
        {
            Rect = bounds;
        }

        public override Vector2 Position
        {
            get => Rect.Location;
            set => Rect.Location = value;
        }

        public override float Distance(Vector2 vec)
        {
            float dx = MathF.Max(MathF.Max(Rect.Left - vec.X, vec.X - Rect.Right), 0);
            float dy = MathF.Max(MathF.Max(Rect.Top - vec.Y, vec.Y - Rect.Bottom), 0);
            return MathF.Sqrt(dx * dx + dy * dy);
        }

        public override RectangleF GetBounds()
        {
            return Rect;
        }

        public override void DebugDraw()
        {
            Render.HollowRect(Rect.X, Rect.Y, Rect.Width, Rect.Height, Color.Red);
        }

        public override bool Check(Hitbox hb)
        {
            return hb.Rect.Intersects(Rect);
        }

        public override bool Check(Circle circ)
        {
            return Distance(circ.Position) < circ.Radius;
        }
    }
}
