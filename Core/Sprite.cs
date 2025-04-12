using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Projeto_1.Core;

public class Sprite
{
    public Texture2D Texture;
    public Vector2 Position;
    public Vector2 Scale;

    public Rectangle rect
    {
        get
        {
            return new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                Convert.ToInt32(Texture.Width * Scale.X),
                Convert.ToInt32(Texture.Height * Scale.Y)
            );
        }
    }

    public Sprite()
    {

    }

    public Sprite(Texture2D texture, Vector2 position)
    {
        Texture = texture;
        Position = position;
        Scale = new Vector2(1, 1);
    }

    public Sprite(Texture2D texture, Vector2 position, Vector2 scale) : this(texture, position)
    {
        Scale = scale;
    }

    public virtual void Update(GameTime gameTime)
    {

    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, rect, Color.White);
    }
}
