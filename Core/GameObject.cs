using Microsoft.Xna.Framework;

namespace Projeto_1.Core;

public class GameObject
{
    public Transform Transform;

    public GameObject()
    {

    }

    public GameObject(Vector2 position) : this()
    {
        Transform.Position = position;
    }

    public GameObject(Vector2 position, Vector2 scale) : this(position)
    {
        Transform.Scale = scale;
    }

    public virtual void Update(GameTime gameTime)
    {

    }
}
