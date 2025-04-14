using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projeto_1.Core;
using Projeto_1.Objects;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Projeto_1.Core.Resources;

namespace Projeto_1.Levels
{
    public class Sokoban : Game
    {
        #region CORE
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        #endregion

        int tileSize = 64;

        #region OBJETOS
        Player _player;
        Block _box;

        Dictionary<Vector2, int> tileMap;
        List<Rectangle> textureStore;
        List<Block> _mapBlock;
        #endregion

        #region TEXTURES
        Texture2D atlasTexture;
        Texture2D playerTexture;
        #endregion

        public Sokoban()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            textureStore = new()
            {
                new Rectangle(0, 0, 16, 16),
                new Rectangle(16, 0, 16, 16),
                new Rectangle(32, 0, 16, 16)
            };
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

        private void LoadMap()
        {
            foreach (var mapTile in tileMap)
            {
                var texture = textureStore[mapTile.Value - 1];
                var sprite = new Sprite(atlasTexture, new Vector2(mapTile.Key.X * tileSize, mapTile.Key.Y * tileSize), texture, new Vector2(64, 64));
                var _block = new Block(new Vector2(mapTile.Key.X * tileSize, mapTile.Key.Y * tileSize), new Vector2(1, 1), sprite);
                _mapBlock.Add(_block);
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            //TEXTURAS
            atlasTexture = Content.Load<Texture2D>("Sokoban_Sprite_Atlas");
            playerTexture = Content.Load<Texture2D>("BoxBlock1");

            //MAP
            tileMap = LoadSpriteAtlas("../../../Levels/Map1.csv");
            _mapBlock = new();
            LoadMap();

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

            foreach(var block in _mapBlock)
            {
                block.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            //MAPA
            foreach(var block in _mapBlock)
                block.Sprite.Draw(_spriteBatch);

            //PLAYER
            //_player.Sprite.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
