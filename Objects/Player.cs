using Projeto_1.Core;
using Microsoft.Xna.Framework;
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

    public Player(Vector2 position) : this()
    {
        Transform.Position = position;
        Transform.Scale = new Vector2(1, 1);
    }

    public Player(Vector2 position, Sprite sprite) : this(position)
    {
        Transform.Scale = new Vector2(1, 1);
        Sprite = sprite;
    }

    public Player(Vector2 position, Vector2 scale, Sprite sprite) : this(position, sprite)
    {
        Transform.Scale = scale;
    }

    public void UpdateSprite()
    {
        Sprite.Rect.X = (int)Transform.Position.X;
        Sprite.Rect.Y = (int)Transform.Position.Y;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        UpdateSprite();

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
