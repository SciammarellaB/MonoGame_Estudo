using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projeto_1.Core;
using Projeto_1.Objects;
using System.Collections.Generic;
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

        #region OBJETOS
        Player _player;
        Block _box;

        int displayTileSize = 64;
        int textureTileSize = 16;
        int textureTilesRow = 8;

        Dictionary<Vector2, int> tileMap;
        List<Block> _mapBlock;
        
        Dictionary<Vector2, int> collisionMap;

        #endregion

        #region TEXTURES
        Texture2D atlasTexture;
        Texture2D collisionTexture;
        Texture2D playerTexture;
        #endregion

        public Sokoban()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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
            foreach (var item in tileMap)
            {
                Rectangle rect = new(
                    (int)item.Key.X * displayTileSize,
                    (int)item.Key.Y * displayTileSize,
                    displayTileSize,
                    displayTileSize
                );

                int x = item.Value % textureTilesRow;
                int y = item.Value / textureTilesRow;

                Rectangle src = new(
                    x * textureTileSize,
                    y * textureTileSize,
                    textureTileSize,
                    textureTileSize
                );

                var sprite = new Sprite(atlasTexture, rect, src);
                var _block = new Block(new Vector2(item.Key.X * displayTileSize, item.Key.Y * displayTileSize), new Vector2(displayTileSize, displayTileSize), sprite);
                _mapBlock.Add(_block);
            }
        }

        private void DebugMapCollision()
        {
            foreach(var item in collisionMap)
            {
                Rectangle rect = new(
                    (int)item.Key.X * displayTileSize,
                    (int)item.Key.Y * displayTileSize,
                    displayTileSize,
                    displayTileSize
                );

                int x = item.Value % textureTilesRow;
                int y = item.Value / textureTilesRow;

                Rectangle src = new(
                    x * textureTileSize,
                    y * textureTileSize,
                    textureTileSize,
                    textureTileSize
                );

                _spriteBatch.Draw(collisionTexture, rect, src, Color.White);
            }
        }

        private void LoadPlayer()
        {
            Rectangle rect = new(
                    0,
                    0,
                    displayTileSize,
                    displayTileSize
                );

            int x = 0 % textureTilesRow;
            int y = 0 / textureTilesRow;

            Rectangle src = new(
                x * textureTileSize,
                y * textureTileSize,
                textureTileSize,
                textureTileSize
            );

            var sprite = new Sprite(playerTexture, rect, src);
            _player = new Player(new Vector2(64 ,64), new Vector2(displayTileSize, displayTileSize), sprite);
            _player.Velocidade = 64;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            //TEXTURAS
            atlasTexture = Content.Load<Texture2D>("Sokoban_Sprite_Atlas");
            collisionTexture = Content.Load<Texture2D>("Sokoban_Collision_Atlas");
            playerTexture = Content.Load<Texture2D>("Sokoban_Player_SpriteSheet");

            //MAP
            tileMap = LoadSpriteAtlas("../../../Levels/Map1.csv");
            _mapBlock = new();
            LoadMap();

            //COLLISION MAP
            collisionMap = LoadSpriteAtlas("../../../Levels/Map1_Collision.csv");

            //PLAYER
            LoadPlayer();
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

            DebugMapCollision();

            //PLAYER
            _player.Sprite.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
