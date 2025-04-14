using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Projeto_1.Core;

public class Sprite
{
    public Texture2D Texture;
    public Rectangle Rect;
    public Rectangle Src;

    public Sprite()
    {

    }

    public Sprite(Texture2D texture, Rectangle rect, Rectangle src) : this()
    {
        Texture = texture;
        Rect = rect;
        Src = src;
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Rect, Src, Color.White);
    }
}
