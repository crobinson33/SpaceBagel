using System;
using System.Collections.Generic;

namespace SpaceBagel
{
	public class Level
	{
        public List<BaseObject> objects;
        public List<Light> lights;
        public Surface diffuseSurface;
        public Surface lightMap;
        public Camera camera;
        public Color ambientColor;
        public Shader lightMapShader;

        public World world;

        public Mouse mouse;

        public Level(Surface diffuseSurface, Surface lightMap, Mouse mouse, Camera camera, Color ambientColor)
        {
            objects = new List<BaseObject>();
            lights = new List<Light>();
            this.diffuseSurface = diffuseSurface;
            this.lightMap = lightMap;
            this.lightMap.renderStates.BlendMode = SFML.Graphics.BlendMode.Multiply;
            Console.WriteLine("surface created");
            this.camera = camera;
            world = new World();
            this.mouse = mouse;
            this.ambientColor = ambientColor;
        }

        public void AddObject(BaseObject newObject)
        {
            objects.Add(newObject);
        }

        public void RemoveObject(BaseObject oldObject)
        {
            objects.Remove(oldObject);
        }

        public void AddLight(Light newLight)
        {
            newLight.shader.SetParameter("thisLightColor", newLight.color);
            newLight.shader.SetParameter("thisLightIntensity", newLight.intensity);
            lights.Add(newLight);
        }

        public void RemoveLight(Light oldLight)
        {
            lights.Remove(oldLight);
        }

        public void Update(float deltaTime)
        {
            foreach(BaseObject obj in objects)
            {
                obj.Update(deltaTime);
            }

            foreach (Light light in lights)
            {
                light.Update(deltaTime);
            }

            world.Update(deltaTime);

        }

        public void Draw(float deltaTime)
        {
            foreach(BaseObject obj in objects)
            {
                obj.Draw(diffuseSurface, deltaTime);
            }

            foreach (Light light in lights)
            {
                light.Draw(lightMap, deltaTime);
            }
            diffuseSurface.Draw(lightMap, deltaTime);
        }
	}
}

