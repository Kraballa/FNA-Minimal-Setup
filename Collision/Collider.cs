using Microsoft.Xna.Framework;
using Namespace.Util;

namespace Namespace.Collision
{
    public abstract class Collider : ICollider
    {
        public abstract Vector2 Position { get; set; }

        public abstract float Distance(Vector2 vec);
        public abstract RectangleF GetBounds();

        public abstract bool Check(Hitbox hb);
        public abstract bool Check(Circle circ);

        public virtual void DebugDraw()
        {

        }

        public bool Collides(ICollider other)
        {
            if (GetBounds().Intersects(other.GetBounds()))
            {
                if (other is Hitbox)
                {
                    return Check(other as Hitbox);
                }
                if (other is Circle)
                {
                    return Check(other as Circle);
                }
            }
            return false;
        }
    }
}
