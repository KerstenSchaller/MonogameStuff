using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GameCore
{
    public class Label : VisualComponent
    {
        private SpriteFont font;
        public string Text = "Label: Text not set";

        public Label(Vector2 _position)
        {
            this.position = _position;
            font = GenericGameObjectsFactory.getContentManager().Load<SpriteFont>("Arial");
        }

        public override void DrawComponent(SpriteBatch _spriteBatch)
        {
            _spriteBatch.DrawString(font, Text, this.Position, Color.Black);
        }

        public override void updateComponent(float elapsedTimeSeconds)
        {

        }
    }

    class CoordinatesLabel : Label, IObserver
    {
        public CoordinatesLabel(Vector2 pos) : base(pos)
        {
            
        }

        public void Update(ISubject subject)
        {
            int pos_x = (int)((VisualComponent)subject).Position.X;
            int pos_y = (int)((VisualComponent)subject).Position.Y;
            this.Text = "X: " + pos_x  + " Y: " + pos_y;
        }
    }


}
