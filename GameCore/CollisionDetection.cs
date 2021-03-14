

using Microsoft.Xna.Framework;

namespace GameCore
{
    class CollisionDetection
    {
        public static bool getAxisAlignedRectangleCollision(Rectangle rect1, Rectangle rect2)
        {

            if ((rect1.X < rect2.X + rect2.Width) &&
                 (rect1.X + rect1.Width > rect2.X) &&
                 (rect1.Y < rect2.Y + rect2.Height) &&
                 (rect1.Y + rect1.Height > rect2.Y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool getPixelPerfectSpriteCollision(VisualComponent component1, VisualComponent component2) 
        {
            Rectangle sourceRectangle = new Rectangle((int)component1.Position.X, (int)component1.Position.Y, component1.SegmentTexture.Width, component1.SegmentTexture.Height); ;
            Color[] retrievedColor = new Color[1];

            component1.SegmentTexture.GetData<Color>(
                                                        0,
                                                        sourceRectangle,
                                                        retrievedColor,
                                                        0,
                                                        1);
            return false;
        }

    }
}
