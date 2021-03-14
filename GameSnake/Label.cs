using GameCore;
using Microsoft.Xna.Framework;

namespace SnakeGame
{
  
    class PointsLabel : Label, IObserver
    {
        public PointsLabel(Vector2 pos) : base(pos)
        {

        }


        public void Update(ISubject subject)
        {
            this.Text = "Points: " + ((Snake)subject).ApplesEaten;
        }
    }

}
