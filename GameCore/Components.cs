using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameCore
{
    public abstract class Component : SubjectImplementation
    {
        public abstract void updateComponent(float elapsedTimeSeconds);

        protected List<Component> childs = new List<Component>();

        public void deactivate()
        {
            ComponentManager.detachComponent(this);
        }

        public void attachChild(Component childComponent)
        {
            childs.Add(childComponent);
            ComponentManager.attachComponent(childComponent);
        }


    }

    public abstract class VisualComponent : Component
    {
        protected Texture2D segmentTexture;
        protected Vector2 position;
        protected bool collidable;

        public virtual void DrawComponent(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(this.SegmentTexture, this.Position, Color.White);
        }

        public VisualComponent() 
        {
            collidable = false;
        }

        public VisualComponent(bool _collidable)
        {
            collidable = _collidable;
        }

        public Texture2D SegmentTexture { get { return segmentTexture; } }
        public Vector2 Position { get { return position; } }
        public bool getCollision(VisualComponent otherComponent) 
        {
            //rectangle based collision
            if (this.collidable == false) 
            {
                return false;
            }
            else
            {
                Rectangle rect1 = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.SegmentTexture.Width, this.segmentTexture.Height);
                Rectangle rect2 = new Rectangle((int)otherComponent.Position.X, (int)otherComponent.Position.Y, otherComponent.SegmentTexture.Width, otherComponent.segmentTexture.Height);
                return CollisionDetection.getAxisAlignedRectangleCollision(rect1, rect2);

            }
        }

        
    }


}
