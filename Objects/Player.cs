using Projeto_1.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Projeto_1.Objects;

public class Player : GameObject
{
    public Sprite Sprite {  get; set; }

    public int Velocidade { get; set; }

    public Player()
    {
        Transform = new Transform();
        Sprite = new Sprite();

        Velocidade = 10;
    }

    public Player(Vector2 position, Texture2D texture) : this()
    {
        Transform.Position = position;
        Transform.Scale = new Vector2(1, 1);
        Sprite.Texture = texture;
        Sprite.Position = Transform.Position;
        Sprite.Scale = Transform.Scale;
    }

    public Player(Vector2 position, Vector2 scale, Texture2D texture) : this(position, texture)
    {
        Transform.Scale = scale;
        Sprite.Scale = Transform.Scale;
    }

    public void Atualizacao()
    {
        Sprite.Position = Transform.Position;
        Sprite.Scale = Transform.Scale;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        Atualizacao();

        //KEYBOARD
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            Transform.Position.Y -= Velocidade;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            Transform.Position.Y += Velocidade;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            Transform.Position.X -= Velocidade;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            Transform.Position.X += Velocidade;
        }

        //MOUSE
        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {

        }
    }
}
