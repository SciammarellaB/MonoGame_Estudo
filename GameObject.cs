using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Projeto_1;

internal class GameObject : Sprite
{
    public bool Locked;
    List<GameObject> collisionGroup;

    public GameObject(Texture2D texture, Vector2 position, List<GameObject> collisionGroup) : base(texture, position)
    {
        this.collisionGroup = collisionGroup;
    }

    public GameObject(Texture2D texture, Vector2 position, float scale, List<GameObject> collisionGroup) : base(texture, position, scale)
    {
        this.collisionGroup = collisionGroup;
    }

    public override void Update(GameTime gameTime)
    {
        if (!Locked)
        {
            position.Y++;

            foreach (var collisionObject in collisionGroup)
            {
                if (collisionObject != this && collisionObject.rect.Intersects(rect))
                {
                    position.Y--;
                }
            }
        }
    }
}
