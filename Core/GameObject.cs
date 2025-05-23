﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Projeto_1.Core;

public class GameObject
{
    public Transform Transform;

    public bool CanCollide;

    public GameObject()
    {
        CanCollide = true;
    }

    public GameObject(Vector2 position) : this()
    {
        Transform.Position = position;
        Transform.Scale = new Vector2(1, 1);
    }

    public GameObject(Vector2 position, Vector2 scale) : this(position)
    {
        Transform.Scale = scale;
    }

    public virtual void Update(GameTime gameTime)
    {
        Transform.Bounds = new Rectangle(
            (int)Transform.Position.X,
            (int)Transform.Position.Y,
            (int)Transform.Scale.X,
            (int)Transform.Scale.Y
        );
    }
}
