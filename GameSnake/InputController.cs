using Microsoft.Xna.Framework.Input;

using GameCore;

namespace SnakeGame
{
    class InputController : Component 
    {

        Snake snake;
        public InputController(Snake _snake) 
        {
            snake = _snake;
        }

        public override void updateComponent(float elapsedTimeSeconds)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up)) snake.changeDirection(Direction.NORTH);

            if (kstate.IsKeyDown(Keys.Down)) snake.changeDirection(Direction.SOUTH);

            if (kstate.IsKeyDown(Keys.Left)) snake.changeDirection(Direction.WEST);

            if (kstate.IsKeyDown(Keys.Right)) snake.changeDirection(Direction.EAST);

            if (kstate.IsKeyDown(Keys.Space)) snake.moveTo(new Microsoft.Xna.Framework.Vector2 (50,100));
        }
    }
}
