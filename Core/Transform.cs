using Microsoft.Xna.Framework;

namespace Projeto_1.Core;

public class Transform
{
    public Vector2 Position;
    public Vector2 Scale;

    public Rectangle Bounds;

    public Transform()
    {

    }

    public Transform(Vector2 position) : this()
    {
        Position = position;
    }

    public Transform(Vector2 position, Vector2 scale) : this(position)
    {
        Scale = scale;
    }
}
