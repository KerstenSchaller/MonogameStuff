

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameCore
{
    public class CollisionDetection
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


        /* This stuff was nonsense but maybe some codesnippets can be reused later */
        /*
        public static Int32 returnWorldFrameMask(VisualComponent component1)
        {
            // get color pixel wise
            Texture2D texture = component1.SegmentTexture;
            int dataLength = texture.Width * texture.Height;

            Color[] retrievedColors = new Color[dataLength];
            bool[] mask = new bool[dataLength];

            texture.GetData<Color>(retrievedColors);

            for (int i = 0; i < retrievedColors.Length; i++)
            {
                if (retrievedColors[i] == new Color(255, 255, 255, 255))
                {
                    // white pixel
                    mask[i] = false;
                }
                else 
                {
                    mask[i] = true;
                }
            }

        }

        private Int32 setSingleBit(int index, int value) 
        {
            return value = value | (0b1 << index);
        }

        public static bool getPixelPerfectSpriteCollision(VisualComponent component1, VisualComponent component2) 
        {
            return false;
        }
        */

    }
}
