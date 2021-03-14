using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using GameCore;


namespace SnakeGame
{

    public enum Direction { NORTH, EAST, SOUTH, WEST };

    class Snake : VisualComponent, IObserver
    {
        public bool alive = true;

        int SegmentID = 0;
        private int applesEaten = 0;
        private float speed = 100;
        private Direction direction;
        
        private Vector2 wayPoint = new Vector2();
        private Direction wayPointDirection;
        private bool wayPointActive = false;

        private Vector2 jumpPoint = new Vector2();
        private Vector2 jumpDestination = new Vector2();
        private bool jumpPointActive = false;

        public int ApplesEaten { get { return applesEaten; } }

        public Snake(Texture2D _segmentTexture, Direction _direction,Vector2 startPos, int startGrowth, int _segmentId = 0) : base(true)
        {
            segmentTexture = _segmentTexture;
            direction = _direction;
            position = startPos;
            SegmentID = _segmentId;
            for (int i = 0; i < startGrowth; i++)
            {
                Snake childSnakeSegment = this.grow();
                childSnakeSegment.Attach(this);
            }
        }

        private void eat(Apple food)
        {
            food.getEaten();
            grow();
            applesEaten++;
        }

        public void moveTo(Vector2 newPosition)
        {

            foreach (var child in childs)
            {
                if (child is Snake)
                {
                    ((Snake)child).moveToLocationAt(this.position, newPosition);
                }
            }

            position = newPosition;

        }




        public override void updateComponent(float elapsedTimeSeconds)
        {
            this.move(elapsedTimeSeconds);
            this.Notify();
        }

        private Snake grow() 
        {
            Snake snake;
            foreach (var child in childs)
            {
                if (child is Snake) 
                {
                    snake = ((Snake)child).grow();
                    return snake;
                }
            }

            var sizeX = segmentTexture.Width;
            var sizeY = segmentTexture.Height;
            Vector2 segmentPos = new Vector2(this.position.X, this.position.Y);

            switch (this.direction)
            {
                case Direction.NORTH:
                    segmentPos.Y += sizeY;
                    break;
                case Direction.EAST:
                    segmentPos.X -= sizeX;
                    break;
                case Direction.SOUTH:
                    segmentPos.Y -= sizeY;
                    break;
                case Direction.WEST:
                    segmentPos.X += sizeX;
                    break;
                default:
                    break;
            }
            Snake snakeSegment = new Snake(this.segmentTexture, this.direction, segmentPos, 0, this.SegmentID + 1);
            this.attachChild(snakeSegment);
            return snakeSegment;
        }

        private void move(float elapsedTimeSeconds)
        {
            if (direction == Direction.NORTH)
                position.Y -= speed * elapsedTimeSeconds;

            if (direction == Direction.SOUTH)
                position.Y += speed * elapsedTimeSeconds;

            if (direction == Direction.WEST)
                position.X -= speed * elapsedTimeSeconds;

            if (direction == Direction.EAST)
                position.X += speed * elapsedTimeSeconds;

            checkWayPoint();
            checkJumpPoint();



        }

        private void checkWayPoint() 
        {
            if (wayPointActive == true)
            {
                switch (direction)
                {
                    case Direction.NORTH:
                        if ((int)position.Y <= (int)wayPoint.Y)
                        {
                            this.changeDirection(wayPointDirection);
                            wayPointActive = false;
                        }
                        break;
                    case Direction.EAST:
                        if ((int)position.X >= (int)wayPoint.X )
                        {
                            this.changeDirection(wayPointDirection);
                            wayPointActive = false;
                        }
                        break;
                    case Direction.SOUTH:
                        if ((int)position.Y >= (int)wayPoint.Y)
                        {
                            this.changeDirection(wayPointDirection);
                            wayPointActive = false;
                        }
                        break;
                    case Direction.WEST:
                        if ((int)position.X <= (int)wayPoint.X )
                        {
                            this.changeDirection(wayPointDirection);
                            wayPointActive = false;
                        }
                        break;
                    default:
                        break;
                }

            }
        }


        private void checkJumpPoint()
        {
            if (jumpPointActive == true)
            {
                switch (direction)
                {
                    case Direction.NORTH:
                        if ((int)position.Y <= (int)jumpPoint.Y)
                        {
                            this.moveTo(jumpDestination);
                            jumpPointActive = false;
                        }
                        break;
                    case Direction.EAST:
                        if ((int)position.X >= (int)jumpPoint.X)
                        {
                            this.moveTo(jumpDestination);
                            this.changeDirection(wayPointDirection);
                            jumpPointActive = false;
                        }
                        break;
                    case Direction.SOUTH:
                        if ((int)position.Y >= (int)jumpPoint.Y)
                        {
                            this.moveTo(jumpDestination);
                            this.changeDirection(wayPointDirection);
                            jumpPointActive = false;
                        }
                        break;
                    case Direction.WEST:
                        if ((int)position.X <= (int)jumpPoint.X)
                        {
                            this.moveTo(jumpDestination);
                            this.changeDirection(wayPointDirection);
                            jumpPointActive = false;
                        }
                        break;
                    default:
                        break;
                }

            }
        }

        public void changeDirection(Direction _direction)
        {
            switch (direction)
            {
                // do not allow 180 turns
                case Direction.NORTH:
                    if(_direction != Direction.SOUTH)direction = _direction;
                    break;
                case Direction.EAST:
                    if (_direction != Direction.WEST) direction = _direction;
                    break;
                case Direction.SOUTH:
                    if (_direction != Direction.NORTH) direction = _direction;
                    break;
                case Direction.WEST:
                    if (_direction != Direction.EAST) direction = _direction;
                    break;
                default:
                    break;
            }
            
            

            foreach (var child in childs)
            {
                if(child is Snake) 
                {
                    ((Snake)child).changeDirectionAt(_direction, this.position);
                }
            }
        }

        private void changeDirectionAt(Direction _direction, Vector2 _wayPoint)
        {
            wayPoint = _wayPoint;
            wayPointDirection = _direction;
            wayPointActive = true;
        }

        private void moveToLocationAt(Vector2 _jumpPoint, Vector2 _jumpDest)
        {
            jumpPoint = _jumpPoint;
            jumpDestination = _jumpDest;
            jumpPointActive = true;


        }


        public void Update(ISubject subject)
        {
            if (subject is Apple)
            {
                var apple = (Apple)subject;
                if (apple.getCollision(this))
                {
                    this.eat(apple);
                }
            }
            if (subject is Snake) 
          
            {

                var snakesegment = (Snake)subject;
                if (this.SegmentID == 0) // only snakehead cares about collisions
                {
                    if (snakesegment.SegmentID != 1 && snakesegment.getCollision(this))
                    {
                        alive = false;
                    }
                }
                
            }
        }
    }

  
}
