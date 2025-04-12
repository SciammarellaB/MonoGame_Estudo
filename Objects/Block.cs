using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Projeto_1.Core;

namespace Projeto_1.Objects;

public class Block : GameObject
{
    public Sprite Sprite { get; set; }

    public int Velocidade { get; set; }

    public Block()
    {
        Transform = new Transform();
        Sprite = new Sprite();

        Velocidade = 10;
    }

    public Block(Vector2 position, Texture2D texture) : this()
    {
        Transform.Position = position;
        Transform.Scale = new Vector2(1, 1);
        Sprite.Texture = texture;
        Sprite.Position = Transform.Position;
        Sprite.Scale = Transform.Scale;
    }

    public Block(Vector2 position, Vector2 scale, Texture2D texture) : this(position, texture)
    {
        Transform.Scale = scale;
        Sprite.Scale = Transform.Scale;
    }
}
