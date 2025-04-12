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

        List<GameObject> _gameObjects;
        Player _player;

        public Sokoban()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            _gameObjects = new();

            Texture2D playerTexture = Content.Load<Texture2D>("frog");
            Texture2D bloco = Content.Load<Texture2D>("Bloco");

            //PLAYER
            _player = new Player(new Vector2(100, 100), new Vector2(0.5f, 0.5f), playerTexture);

            //var _bloco = new GameObject(bloco, new Vector2(640, 320), _gameObjects);
            //_bloco.Locked = true;
            //_gameObjects.Add(_bloco);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //PLAYER
            _player.Update(gameTime);

            foreach (var gameObject in _gameObjects)
                gameObject.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            //PLAYER
            _player.Sprite.Draw(_spriteBatch);

            //OBJETOS
            //foreach (var gameObject in _gameObjects)
            //    gameObject.Sprite.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
