using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Projeto_1;

internal class Sprite
{
    public Texture2D Texture;
    public Vector2 Position;
    public Rectangle Rect;

    public Sprite()
    {

    }

    public Sprite(Texture2D texture, Vector2 position)
    {
        Texture = texture;
        Position = position;
    }

    public Sprite(Texture2D texture, Rectangle rect)
    {
        Texture = texture;
        Rect = rect;
        Position.X = rect.X;
        Position.Y = rect.Y;
    }
}
