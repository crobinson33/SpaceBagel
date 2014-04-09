using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBagel
{
    public class RenderLayer
    {
        internal SFML.Graphics.VertexArray vertexArray;
        public Texture texture;
        public SFML.Graphics.RenderStates renderStates;
        public int z;

        public RenderLayer(Texture texture, int z)
        {
            this.z = z;
            vertexArray = new SFML.Graphics.VertexArray(SFML.Graphics.PrimitiveType.Quads, 0);
            renderStates = SFML.Graphics.RenderStates.Default;
            renderStates.Texture = texture.source;
            renderStates.BlendMode = SFML.Graphics.BlendMode.None;
        }

        public void AddDrawable(Sprite sprite, Vector2 position)
        {
            vertexArray.Append(new Vertex(sprite.quad.TopLeft + position, sprite.color, sprite.TextureTopLeft).SFMLVertex);
            vertexArray.Append(new Vertex(sprite.quad.TopRight + position, sprite.color, sprite.TextureTopRight).SFMLVertex);
            vertexArray.Append(new Vertex(sprite.quad.BottomRight + position, sprite.color, sprite.TextureBottomRight).SFMLVertex);
            vertexArray.Append(new Vertex(sprite.quad.BottomLeft + position, sprite.color, sprite.TextureBottomLeft).SFMLVertex);
        }

        public void RemoveDrawable(BaseDrawable drawable)
        {

        }
    }
}
