using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Projeto_1;

internal class Player : GameObject
{
    public Player(Texture2D texture, Vector2 position, List<GameObject> collisionGroup) : base(texture, position, collisionGroup)
    {

    }

    public Player(Texture2D texture, Vector2 position, float scale, List<GameObject> collisionGroup) : base(texture, position, scale, collisionGroup)
    {

    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        //KEYBOARD
        if (Keyboard.GetState().IsKeyDown(Keys.Up)) 
        {
            position.Y--;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            position.Y++;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            position.X--;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            position.X++;
        }

        //MOUSE
        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            
        }
    }
}
