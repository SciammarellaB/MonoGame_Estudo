using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Projeto_1.Core;

public class Sprite
{
    public Texture2D Texture;
    public Vector2 Position;
    public Vector2 Scale;
    public Rectangle Src;

    public Rectangle rect
    {
        get
        {
            return new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                (int)Scale.X,
                (int)Scale.Y
            );
        }
    }

    public Sprite()
    {

    }

    public Sprite(Texture2D texture, Vector2 position, Rectangle src)
    {
        Texture = texture;
        Position = position;
        Scale = new Vector2(1, 1);
        Src = src;
    }

    public Sprite(Texture2D texture, Vector2 position, Rectangle src, Vector2 scale) : this(texture, position, src)
    {
        Scale = scale;
    }

    public virtual void Update(GameTime gameTime)
    {

    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, rect, Src, Color.White);
    }
}
