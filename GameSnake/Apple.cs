using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameCore;

namespace SnakeGame
{
    class Apple : VisualComponent
    {
        private bool eaten = false;
        
        public bool Eaten { get { return this.eaten; } }

        public Apple(Texture2D _segmentTexture, Vector2 _position) : base(true)
        {
            segmentTexture = _segmentTexture;
            position = _position;

 
        }

        public void getEaten() 
        {
            this.eaten = true;
            this.collidable = false;
            this.Notify();
            base.deactivate();
        }

        public override void updateComponent(float elapsedTimeSeconds)
        {
            this.Notify();
        }
    }
}
