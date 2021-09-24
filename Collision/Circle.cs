using Microsoft.Xna.Framework;
using Namespace.Util;

namespace Namespace.Collision
{
    public class Circle : Collider
    {
        public float Radius;

        private Vector2 position;

        public override Vector2 Position { get => position; set => position = value; }

        public Circle(Vector2 pos, float radius)
        {
            position = pos;
            Radius = radius;
        }

        public override bool Check(Hitbox hb)
        {
            return hb.Distance(Position) < Radius;
        }

        public override bool Check(Circle circ)
        {
            return (circ.Position - Position).Length() < circ.Radius + Radius;
        }

        public override float Distance(Vector2 vec)
        {
            return Radius;
        }

        public override RectangleF GetBounds()
        {
            return new RectangleF(Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
        }

        public override void DebugDraw()
        {
            Render.Circle(Position, Radius, Color.Red, 4);
        }
    }
}
