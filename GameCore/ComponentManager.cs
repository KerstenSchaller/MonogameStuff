using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameCore
{
    public static class ComponentManager
    {
        static List<Component> components = new List<Component>();
        
        public static void attachComponent(Component component) 
        {
            components.Add(component);
        }

        public static void detachComponent(Component component)
        {
            components.Remove(component);
        }

        public static void updateComponents(float elapsedTimeSeconds) 
        {
           
            var components_arr = components.ToArray();
            foreach (Component component in components_arr) 
            {
                component.updateComponent(elapsedTimeSeconds);
            }
        }

        public static void drawVisualComponents(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();

            foreach (Component component in components)
            {
                if (component is VisualComponent) 
                {
                    ((VisualComponent)component).DrawComponent(_spriteBatch);
                }
            }
            _spriteBatch.End();
        }




    }
}
