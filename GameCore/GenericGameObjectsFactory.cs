using Microsoft.Xna.Framework;

namespace GameCore
{
    public static class GenericGameObjectsFactory
    {
        static Microsoft.Xna.Framework.Content.ContentManager contentManager;
        static GraphicsDeviceManager graphics;
        public static void init(Microsoft.Xna.Framework.Content.ContentManager _contentManager, GraphicsDeviceManager _graphics) 
        {
            contentManager = _contentManager;
            graphics = _graphics;
        }
        public static Microsoft.Xna.Framework.Content.ContentManager getContentManager() 
        {
            return contentManager;
        }

        public static GraphicsDeviceManager getGraphics() 
        {
            return graphics;
        }
    }
}
