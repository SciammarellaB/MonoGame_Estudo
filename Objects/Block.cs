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

    public Block(Vector2 position, Sprite sprite) : this()
    {
        Transform.Position = position;
        Transform.Scale = new Vector2(1, 1);
        Sprite = sprite;
    }

    public Block(Vector2 position, Vector2 scale, Sprite sprite) : this(position, sprite)
    {
        Transform.Scale = scale;
    }

    public override void Update(GameTime gameTime)
    {
        UpdateCollisionBox(gameTime);
    }

    public override void UpdateCollisionBox(GameTime gameTime)
    {
        ColisionBox = new Rectangle((int)Transform.Position.X, (int)Transform.Position.Y, (int)Transform.Scale.X * Sprite.Texture.Width, (int)Transform.Scale.Y * Sprite.Texture.Height);
    }

    //public void DrawCollisionBox(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
    //{
    //    var line = new Texture2D(graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
    //    line.SetData(new[] { Color.White });

    //    //spriteBatch.Draw(line, new Rectangle(ColisionBox.Left, ColisionBox.Top, ColisionBox.Right - ColisionBox.Left, 1), Color.Red);
    //    spriteBatch.Draw(line, new Vector2(Transform.Position.X, Transform.Position.Y), Color.Red);
    //}
}
