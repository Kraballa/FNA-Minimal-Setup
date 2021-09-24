using Microsoft.Xna.Framework;
using Namespace.Util;

namespace Namespace.Collision
{
    public interface ICollider
    {
        public RectangleF GetBounds();
        public float Distance(Vector2 vec);
        public bool Collides(ICollider other);
    }
}
