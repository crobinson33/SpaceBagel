using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    public class Camera
    {
        internal SFML.Graphics.View SFMLView;

        public Camera(Vector2 centerPoint, Vector2 size)
        {
            SFMLView = new SFML.Graphics.View(centerPoint.SFMLVector2, size.SFMLVector2);
        }

        public void SetCenterPosition(Vector2 position)
        {
            SFMLView.Center = position.SFMLVector2;
        }

        public Vector2 GetTopLeftScreenBounds()
        {
            //return new Vector2(SFMLView.Size.X, SFMLView.Size.Y);
            return new Vector2(SFMLView.Center.X - SFMLView.Size.X / 2, SFMLView.Center.Y - SFMLView.Size.Y / 2);
            //return new Vector2(SFMLView.Viewport.Left, SFMLView.Viewport.Top);
        }

        public Vector2 GetBottomRightScreenBounds()
        {
            return new Vector2(SFMLView.Center.X + SFMLView.Size.X / 2, SFMLView.Center.Y + SFMLView.Size.Y / 2);
            //return new Vector2(SFMLView.Viewport.Left + SFMLView.Viewport.Width, SFMLView.Viewport.Top + SFMLView.Viewport.Height);
        }

    }
}
