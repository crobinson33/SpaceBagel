using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceBagel
{
	public class Level
	{
        public List<VisibleObject> backgroundObjs;
        public List<VisibleObject> objects;
        public List<BaseObject> foregroundObjs;
        public List<BaseObject> managerObjects;
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
            backgroundObjs = new List<VisibleObject>();
            objects = new List<VisibleObject>();
            foregroundObjs = new List<BaseObject>();
            managerObjects = new List<BaseObject>();
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

        public void AddObject(VisibleObject newObject)
        {
            objects.Add(newObject);
        }

        public void RemoveObject(VisibleObject oldObject)
        {
            objects.Remove(oldObject);
        }

        public void AddBackgroundObject(VisibleObject newObject)
        {
            backgroundObjs.Add(newObject);
        }

        public void RemoveBackgroundObject(VisibleObject oldObject)
        {
            backgroundObjs.Remove(oldObject);
        }

        public void AddForegroundObject(BaseObject newObject)
        {
            foregroundObjs.Add(newObject);
        }

        public void RemoveForegroundObject(BaseObject oldObject)
        {
            foregroundObjs.Remove(oldObject);
        }

        public void AddManagerObject(BaseObject newObject)
        {
            managerObjects.Add(newObject);
        }

        public void RemoveManagerObject(BaseObject oldObject)
        {
            managerObjects.Remove(oldObject);
        }

        public void AddLight(Light newLight)
        {
            newLight.shader.SetParameter("thisLightIntensity", newLight.intensity);
            lights.Add(newLight);
        }

        public void RemoveLight(Light oldLight)
        {
            lights.Remove(oldLight);
        }

        public void Update(float deltaTime)
        {
            foreach (VisibleObject obj in backgroundObjs)
            {
                obj.Update(deltaTime);
            }

            /*foreach(BaseObject obj in objects)
            {
                obj.Update(deltaTime);
            }*/

            for (int i = objects.Count - 1; i >= 0; i--)
            {
                objects[i].Update(deltaTime);
            }

            // Sort by lowest z, then position + yRenderOffset of a sprite
            this.objects = this.objects.OrderBy(o => o.objectDrawable.z).ThenBy(o => (o.position.Y + o.objectDrawable.yRenderOffset)).ToList();

            foreach (BaseObject obj in foregroundObjs)
            {
                obj.Update(deltaTime);
            }

            foreach (BaseObject manager in managerObjects)
            {
                manager.Update(deltaTime);
            }

            foreach (Light light in lights)
            {
                light.Update(light.position, deltaTime);
            }

            world.Update(deltaTime);

        }

        public void Draw(float deltaTime)
        {
            foreach (VisibleObject obj in backgroundObjs)
            {
                obj.Draw(diffuseSurface, lightMap, deltaTime);
            }

            foreach (VisibleObject obj in objects)
            {
                obj.Draw(diffuseSurface, lightMap, deltaTime);
            }

            foreach (BaseObject obj in foregroundObjs)
            {
                obj.Draw(diffuseSurface, lightMap, deltaTime);
            }

            foreach (Light light in lights)
            {
                light.Draw(lightMap, deltaTime);
            }
            diffuseSurface.Draw(lightMap);
        }
	}
}

