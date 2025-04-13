using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projeto_1.Core;
using Projeto_1.Objects;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projeto_1.Levels
{
    public class Sokoban : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player _player;
        Block _box;

        private Dictionary<Vector2, int> tileMap;
        List<Block> _mapBlock;

        //TEXTURES
        Texture2D playerTexture;
        Texture2D grassBlock;
        Texture2D waterBlock;
        Texture2D boxBlock;

        public Sokoban()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        private Dictionary<Vector2, int> LoadMap(string filePath)
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
                    if(int.TryParse(items[x], out int value))
                    {
                        if (value > 0)
                        {
                            result[new Vector2(x, y)] = value;
                        }
                    }
                }

                y++;
            }

            return result;
        }

        private void DrawMap()
        {
            foreach(var mapTile in tileMap)
            {
                switch (mapTile.Value)
                {
                    case 1:
                        var _waterBlock = new Block(new Vector2(mapTile.Key.X * waterBlock.Width * 4, mapTile.Key.Y * waterBlock.Height * 4), new Vector2(4, 4), waterBlock);
                        _mapBlock.Add(_waterBlock);
                        break;
                    case 2:
                        var _grassTile = new Block(new Vector2(mapTile.Key.X * grassBlock.Width * 4, mapTile.Key.Y * grassBlock.Height * 4), new Vector2(4, 4), grassBlock);
                        _mapBlock.Add(_grassTile);
                        break;
                    case 3:
                        var _boxTile = new Block(new Vector2(mapTile.Key.X * boxBlock.Width * 4, mapTile.Key.Y * boxBlock.Height * 4), new Vector2(4, 4), boxBlock);
                        _mapBlock.Add(_boxTile);
                        break;
                    default:
                        throw new System.Exception("Tile not found");
                }
            }
        }

        protected override void Initialize()
        {
            ChangeScreenResolution(640, 640);

            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected void ChangeScreenResolution(int width, int height)
        {
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges();
        }

        protected int TileType(int x, int y)
        {
            return tileMap.FirstOrDefault(a => a.Key.X == x && a.Key.Y == y).Value;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            //TEXTURAS
            playerTexture = Content.Load<Texture2D>("BoxBlock1");
            grassBlock = Content.Load<Texture2D>("GrassBlock1");
            waterBlock = Content.Load<Texture2D>("WaterBlock1");
            boxBlock = Content.Load<Texture2D>("BoxBlock1");

            //MAP
            tileMap = LoadMap("../../../Levels/Map1.csv");
            _mapBlock = new();
            DrawMap();

            //PLAYER
            _player = new Player(new Vector2(0, 0), new Vector2(4, 4), playerTexture);
            _player.Velocidade = 64;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //PLAYER
            _player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            //MAPA
            foreach (var block in _mapBlock)
            {
                block.Sprite.Draw(_spriteBatch);
            }

            //PLAYER
            _player.Sprite.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
