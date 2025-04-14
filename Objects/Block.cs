using Microsoft.Xna.Framework;
using Projeto_1.Core;

namespace Projeto_1.Objects;

public class Block : GameObject
{
    public Sprite Sprite { get; set; }

    public Block()
    {
        Transform = new Transform();
        Sprite = new Sprite();
    }

    public Block(Vector2 position) : this()
    {
        Transform.Position = position;
        Transform.Scale = new Vector2(1, 1);
    }

    public Block(Vector2 position, Sprite sprite) : this(position)
    {
        Transform.Scale = new Vector2(1, 1);
        Sprite = sprite;
    }

    public Block(Vector2 position, Vector2 scale, Sprite sprite) : this(position, sprite)
    {
        Transform.Scale = scale;
    }
}
