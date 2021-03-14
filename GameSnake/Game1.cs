using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using GameCore;

namespace SnakeGame
{
    public class SnakeGameClass : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Scene scene1;



        public SnakeGameClass()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
            GenericGameObjectsFactory.init(Content, _graphics);

            scene1 = new Scene();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }


            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ComponentManager.updateComponents(elapsedTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            ComponentManager.drawVisualComponents(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
