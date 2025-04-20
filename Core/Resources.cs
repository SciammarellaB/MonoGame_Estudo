using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Projeto_1.Objects;
using System.Collections.Generic;
using System.IO;

namespace Projeto_1.Core;

public static class Resources
{
    #region VARIAVEIS
    public static int displayTileSize = 64;
    public static int textureTileSize = 16;
    public static int textureTilesRow = 8;
    public static bool debugCollision = false;
    #endregion

    #region CORE
    public static GraphicsDeviceManager _graphics;
    public static SpriteBatch _spriteBatch;
    #endregion

    #region OBJETOS
    public static Player _player { get; set; }
    public static Block _box { get; set; }

    public static Dictionary<Vector2, int> tileMap { get; set; }
    public static List<Block> _mapBlock { get; set; }

    public static Dictionary<Vector2, int> collisionMap { get; set; }

    #endregion

    #region METODOS
    public static void ChangeScreenResolution(int width, int height)
    {
        _graphics.PreferredBackBufferWidth = width;
        _graphics.PreferredBackBufferHeight = height;
        _graphics.ApplyChanges();
    }

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

    public static List<Rectangle> GetIntersectingTilesHorizontal(Rectangle target)
    {
        List<Rectangle> intersection = new();
        int widthTiles = (target.Width - (target.Width % displayTileSize)) / displayTileSize;
        int heightTiles = (target.Height - (target.Height % displayTileSize)) / displayTileSize;

        for (int x = 0; x <= widthTiles; x++)
        {
            for (int y = 0; y <= heightTiles; y++)
            {
                intersection.Add(new Rectangle(
                    (target.X + x * displayTileSize) / displayTileSize,
                    (target.Y + y * (displayTileSize - 1)) / displayTileSize,
                    displayTileSize,
                    displayTileSize
                ));
            }
        }

        return intersection;
    }

    public static List<Rectangle> GetIntersectingTilesVertical(Rectangle target)
    {
        List<Rectangle> intersection = new();
        int widthTiles = (target.Width - (target.Width % displayTileSize)) / displayTileSize;
        int heightTiles = (target.Height - (target.Height % displayTileSize)) / displayTileSize;

        for (int x = 0; x <= widthTiles; x++)
        {
            for (int y = 0; y <= heightTiles; y++)
            {
                intersection.Add(new Rectangle(
                    (target.X + x * (displayTileSize - 1)) / displayTileSize,
                    (target.Y + y * displayTileSize) / displayTileSize,
                    displayTileSize,
                    displayTileSize
                ));
            }
        }

        return intersection;
    }

    public static void DrawRectHollow(SpriteBatch spriteBatch, Rectangle rect, int thickness)
    {
        var rectangleTexture = new Texture2D(_graphics.GraphicsDevice, 1, 1);
        rectangleTexture.SetData(new Color[]{ new Color(255, 0, 0, 255) });

        spriteBatch.Draw(
            rectangleTexture,
            new Rectangle(
                rect.X,
                rect.Y,
                rect.Width,
                thickness
            ),
            Color.White
        );
        spriteBatch.Draw(
            rectangleTexture,
            new Rectangle(
                rect.X,
                rect.Bottom - thickness,
                rect.Width,
                thickness
            ),
            Color.White
        );
        spriteBatch.Draw(
            rectangleTexture,
            new Rectangle(
                rect.X,
                rect.Y,
                thickness,
                rect.Height
            ),
            Color.White
        );
        spriteBatch.Draw(
            rectangleTexture,
            new Rectangle(
                rect.Right - thickness,
                rect.Y,
                thickness,
                rect.Height
            ),
            Color.White
        );
    }
    #endregion
}
