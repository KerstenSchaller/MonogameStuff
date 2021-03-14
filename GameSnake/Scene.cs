using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

using GameCore;

namespace SnakeGame
{
    class Scene : Component, IObserver
    {
        InputController inputController;
        Snake snake;
        Apple apple;
        Label label = new Label(new Vector2(100,0));
        
        PointsLabel pointsLabel = new PointsLabel(new Vector2(0, 0));

        public Scene() 
        {
            

            snake = new Snake(GenericGameObjectsFactory.getContentManager().Load<Texture2D>("segment"), Direction.SOUTH,new Vector2(100,100) , 10);
            snake.Attach(this);
            snake.Attach(pointsLabel);
            //snake.Attach(coordinatesLabel);
            label.Text = "";

            inputController = new InputController(snake);

            SpawnAppleRandomly();

            ComponentManager.attachComponent(inputController);
            ComponentManager.attachComponent(snake);
            ComponentManager.attachComponent(pointsLabel);
            ComponentManager.attachComponent(label);
            //ComponentManager.attachComponent(coordinatesLabel);
        }

        private void SpawnAppleRandomly() 
        {
            Random rnd = new Random();
            int maxX = GenericGameObjectsFactory.getGraphics().PreferredBackBufferWidth;
            int maxY = GenericGameObjectsFactory.getGraphics().PreferredBackBufferHeight;

            Vector2 randPos = new Vector2(rnd.Next(maxX), rnd.Next(maxY));
            apple = new Apple(GenericGameObjectsFactory.getContentManager().Load<Texture2D>("apple"), randPos);
            apple.Attach(this);
            apple.Attach(snake);

            ComponentManager.attachComponent(apple);
        }

        public void Update(ISubject subject)
        {
            if (subject is Snake) 
            {
                if (((Snake)subject).alive == true) 
                {
                    this.portalBoundaryCheck();
                }
                else
                {
                    label.Text = "Game Over!";
                }
                
            }

            if (subject is Apple)
            {
                if (apple.Eaten) 
                {
                    SpawnAppleRandomly();
                }
            }

        }

 

        private void portalBoundaryCheck() 
        {
            var screenwidth = GenericGameObjectsFactory.getGraphics().PreferredBackBufferWidth;
            var screenheight = GenericGameObjectsFactory.getGraphics().PreferredBackBufferHeight;

            if (snake.Position.X < 0)
            {
                snake.moveTo(new Vector2(screenwidth, snake.Position.Y));
            }
            if (snake.Position.X > screenwidth)
            {
                snake.moveTo(new Vector2(0, snake.Position.Y));
            }
            if (snake.Position.Y < 0)
            {
                snake.moveTo(new Vector2(snake.Position.X, screenheight));
            }
            if (snake.Position.Y > screenheight)
            {
                snake.moveTo(new Vector2(snake.Position.X, 0));
            }
        }

        public override void updateComponent(float elapsedTimeSeconds)
        {
            
        }
    }
}
