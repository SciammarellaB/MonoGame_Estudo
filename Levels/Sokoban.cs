using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projeto_1.Core;
using Projeto_1.Objects;
using System.Collections.Generic;

namespace Projeto_1.Levels
{
    public class Sokoban : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player _player;

        List<Block> _mapBlock;
        List<int> map = new List<int> {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 1, 1, 1, 0, 0, 1, 1, 1, 0,
            0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
            0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
            0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
            0, 0, 1, 1, 0, 0, 1, 1, 0, 0,
            0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
            0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
            0, 1, 1, 1, 0, 0, 1, 1, 1, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };

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

        protected int TileTyle(int x, int y)
        {
            return map[y * 10 + x];
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            Texture2D playerTexture = Content.Load<Texture2D>("BoxBlock1");            
            Texture2D grassBlock = Content.Load<Texture2D>("GrassBlock1");
            Texture2D waterBlock = Content.Load<Texture2D>("WaterBlock1");
            
            //var _waterTile = new Block(new Vector2(0, 0), new Vector2(4, 4), grassBlock);

            //MAP
            _mapBlock = new();
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    int tile = TileTyle(x, y);

                    switch(tile)
                    {
                        case 1:
                            var _grassTile = new Block(new Vector2(x * grassBlock.Width * 4, y * grassBlock.Height * 4), new Vector2(4, 4), grassBlock);
                            _mapBlock.Add(_grassTile);
                            break;
                        case 2:
                            break;
                        default:
                            var _waterBlock = new Block(new Vector2(x * waterBlock.Width * 4, y * waterBlock.Height * 4), new Vector2(4, 4), waterBlock);
                            _mapBlock.Add(_waterBlock);
                            break;
                    }
                }
            }

            //PLAYER
            _player = new Player(new Vector2(0, 0), new Vector2(4, 4), playerTexture);

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
                block.Sprite.Draw(_spriteBatch);

            //PLAYER
            _player.Sprite.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
