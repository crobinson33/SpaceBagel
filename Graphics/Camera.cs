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

    }
}
