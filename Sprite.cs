using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Projeto_1;

internal class Sprite
{
    public Texture2D texture;
    public Vector2 position;
    public float scale;
    
    public Rectangle rect
    {
        get
        {
            return new Rectangle(
                (int)position.X,
                (int)position.Y,
                texture.Width * (int)scale,
                texture.Height * (int)scale
            );
        }
    }

    public Sprite(Texture2D texture, Vector2 position)
    {
        this.texture = texture;
        this.position = position;
        this.scale = 1;
    }

    public Sprite(Texture2D texture, Vector2 position, float scale) : this(texture, position)
    {
        this.scale = scale;
    }

    public virtual void Update(GameTime gameTime)
    {

    }

    public virtual void Draw(SpriteBatch spriteBatch) 
    {
        spriteBatch.Draw(texture, rect, Color.White);
    }
}
