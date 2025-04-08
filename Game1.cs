using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Projeto_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Sprite _sprite;

        public Game1()
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
            
            Texture2D texture = Content.Load<Texture2D>("frog");
            _sprite = new Sprite(texture, new Rectangle(100, 100, 64, 64));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //USER INPUTS
            //KEYBOARD
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Debug.WriteLine("AAA");
            }
            
            //MOUSE
            if(Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Debug.WriteLine("BBB");
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _spriteBatch.Draw(_sprite.Texture, _sprite.Rect, Color.White);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
