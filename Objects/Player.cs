using Projeto_1.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Projeto_1.Objects;

public class Player : GameObject
{
    public Sprite Sprite {  get; set; }

    public int Velocidade { get; set; }

    //INTERNOS
    public bool CanMove { get; set; }

    public Player()
    {
        Transform = new Transform();
        Sprite = new Sprite();
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

        var velocidade = CanMove ? Velocidade : 0;

        //KEYBOARD
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            Transform.Position.Y -= velocidade;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            Transform.Position.Y += velocidade;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            Transform.Position.X -= velocidade;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            Transform.Position.X += velocidade;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.Right))
            CanMove = false;
        else if (Keyboard.GetState().IsKeyUp(Keys.Up) || Keyboard.GetState().IsKeyUp(Keys.Down) || Keyboard.GetState().IsKeyUp(Keys.Left) || Keyboard.GetState().IsKeyUp(Keys.Right))
            CanMove = true;

        //MOUSE
        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {

        }
    }
}
