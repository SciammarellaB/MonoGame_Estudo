using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;

namespace Projeto_1.Core;

public static class Resources
{
    public static Dictionary<Vector2, int> LoadSpriteAtlas(string filePath)
    {
        Dictionary<Vector2, int> result = new();
        StreamReader reader = new(filePath);

        int y = 0;
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] items = line.Split(',');
            for (int x = 0; x < items.Length; x++)
            {
                if (int.TryParse(items[x], out int value))
                {
                    if (value > -1)
                        result[new Vector2(x, y)] = value;
                }
            }

            y++;
        }

        return result;
    }
}
