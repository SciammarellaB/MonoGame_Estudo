using Projeto_1.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using static Projeto_1.Core.Resources;

namespace Projeto_1.Objects;

public class Player : GameObject
{
    public Sprite Sprite { get; set; }

    public int Velocidade { get; set; }

    public List<Rectangle> Intersections { get; set; }
    public bool CanMove { get; set; }

    //INTERNOS
    Rectangle velocidade = new();

    public Player()
    {
        Transform = new Transform();
        Sprite = new Sprite();
        Intersections = new();
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

        //KEYBOARD
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            velocidade.X -= CanMove ? Velocidade : 0;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            velocidade.X += CanMove ? Velocidade : 0;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            velocidade.Y -= CanMove ? Velocidade : 0;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            velocidade.Y += CanMove ? Velocidade : 0;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.Right))
            CanMove = false;
        else if (Keyboard.GetState().IsKeyUp(Keys.Up) || Keyboard.GetState().IsKeyUp(Keys.Down) || Keyboard.GetState().IsKeyUp(Keys.Left) || Keyboard.GetState().IsKeyUp(Keys.Right))
            CanMove = true;

        //MOUSE
        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {

        }

        UpdateSprite();
        Collision();
    }

    public void Collision()
    {
        Transform.Position.X += 1;
        Intersections = GetIntersectingTilesHorizontal(Transform.Bounds);

        foreach (var rect in Intersections)
        {
            if(collisionMap.TryGetValue(new Vector2(rect.X, rect.Y), out int _val))
            {
                Rectangle collision = new Rectangle(
                    rect.X * displayTileSize,
                    rect.Y * displayTileSize,
                    displayTileSize,
                    displayTileSize
                );

                if(velocidade.X > 0.0f)
                {
                    Transform.Position.X = collision.Left - Transform.Scale.X;
                }
                else if (velocidade.X < 0.0f)
                {
                    Transform.Position.X = collision.Right;
                }
            }
        }

        Intersections = GetIntersectingTilesVertical(Transform.Bounds);
        foreach (var rect in Intersections)
        {
            if (collisionMap.TryGetValue(new Vector2(rect.X, rect.Y), out int _val))
            {
                
            }
        }
    }

    public void DebugPlayerIntersections()
    {
        foreach (var rect in Intersections)
        {
            DrawRectHollow(_spriteBatch, new Rectangle(
                rect.X * displayTileSize,
                rect.Y * displayTileSize,
                displayTileSize,
                displayTileSize
            ), 4);
        }
    }
}
